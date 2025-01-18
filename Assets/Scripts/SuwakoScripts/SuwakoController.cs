using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SuwakoController : MonoBehaviour
{
    //���� ���� �ʿ��� ������
    SuwakoState currentState;
    public Rigidbody2D rb;
    public Animator animator;
    public BoxCollider2D boxCollider;
    
    //������ ���� ��ũ��Ʈ��
    public SuwakoIdleState idleState { get; private set; }
    public SuwakoWalkFrontState walkFrontState { get; private set; }
    public SuwakoFlyingState flyingState { get; private set; }
    public SuwakoJumpingState jumpingState { get; private set; }
    public SuwakoFallingState fallingState { get; private set; }
    public SuwakoLandingState landingState { get; private set; }

    //��ų ���� ��ũ��Ʈ��
    public SuwakoSkill0_ShootingBullet skill0_ShootingBullet {  get; private set; }

    //������ ź�� �߻��ϴ� �� ��ġ
    public Transform bullet0Fire { get; private set; }

    //�¿� �̵� ����
    float _xORy = 5;
    //�������� ���� ����
    float _frontJumpPower = 5;
    //���ƴٴϴ� �Ŀ�
    float _flyingPower = 2;
    //���� �Ŀ�
    float _jumpPower = 10;


    //���� �� ������
    public int falling { get; set; }

    //���� ��
    public bool landing { get; set; }

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

    //�ִϸ��̼��� ���� ������
    public bool isSkill0End =false;
    public bool isLanding =false;

    //���� ��ȯ
    public void ChangeState(SuwakoState newstate)
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
        idleState = new SuwakoIdleState();
        walkFrontState = new SuwakoWalkFrontState();
        flyingState = new SuwakoFlyingState();
        jumpingState = new SuwakoJumpingState();
        fallingState = new SuwakoFallingState();
        landingState = new SuwakoLandingState();

        //��ų ���� ��ũ��Ʈ��
        skill0_ShootingBullet = new SuwakoSkill0_ShootingBullet();


        //���� ��ŸƮ��
        ChangeState(idleState);
    }

    void Update()
    {
        Debug.Log(currentState);
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
        //Ʈ���� Enter
        currentState.OnTriggerEnter2D(this, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Ʈ���� Exit
        currentState.OnTriggerExit2D(this, collision);
    }
}
