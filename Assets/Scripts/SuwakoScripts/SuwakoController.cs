using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SuwakoController : MonoBehaviour
{
    //���� ���� �ʿ��� ������
    State currentState;
    public Rigidbody2D rb;
    public Animator animator;
    public BoxCollider2D boxCollider;

    //������ ���� ��ũ��Ʈ��
    public IdleState idleState { get; private set; }
    public WalkFrontState walkFrontState { get; private set; }
    public FlyingState flyingState { get; private set; }
    public JumpingState jumpingState { get; private set; }
    public FallingState fallingState { get; private set; }


    //�¿� �̵� ����
    float _xORy = 5;
    //�������� ���� ����
    float _frontJumpPower = 10;
    //���ƴٴϴ� �Ŀ�
    float _flyingPower = 2;
    //���� �Ŀ�
    float _jumpPower = 10;


    //���� �¿� Ȱ��
    public int RiORLe { get; set; }

    //������Ƽ��
    public float xORy
    {
        get => _xORy;
    }
    public float frontJumpPower
    {
        get => _frontJumpPower;
    }
    public float flyingPower
    {
        get => _flyingPower;
    }
    public float jumpPower
    {
        get => _jumpPower;
    }

    //���� ��ȯ
    public void ChangeState(State newstate)
    {
        currentState = newstate;
        currentState.Enter(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        //������ ���� ��ũ��Ʈ��
        idleState = new IdleState();
        walkFrontState = new WalkFrontState();
        flyingState = new FlyingState();
        jumpingState = new JumpingState();
        fallingState = new FallingState();

        //���� ��ŸƮ��
        ChangeState(idleState);
    }

    void Update()
    {
        //���� Update
        currentState.Update(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���� OnCollisionEnter2D
        currentState.OnCollisionEnter2D(this, collision);
    }

    void FixedUpdate()
    {
        //���� FixUpdate
        currentState.FixUpdate(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);

        if (collision.tag == "SideWall")
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            if (RiORLe == -1)
            {
                RiORLe = 1;
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (RiORLe == 1)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                RiORLe = -1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit2D(this, collision);
    }
}
