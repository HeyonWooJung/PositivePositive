using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SuwakoController : MonoBehaviour
{
    //유닛 가장 필요한 변수들
    SuwakoState currentState;
    public Rigidbody2D rb;
    public Animator animator;
    public BoxCollider2D boxCollider;
    
    //움직임 상태 스크립트들
    public SuwakoIdleState idleState { get; private set; }
    public SuwakoWalkFrontState walkFrontState { get; private set; }
    public SuwakoFlyingState flyingState { get; private set; }
    public SuwakoJumpingState jumpingState { get; private set; }
    public SuwakoFallingState fallingState { get; private set; }

    //스킬 상태 스크립트들
    public SuwakoSkill0_ShootingBullet skill0_ShootingBullet {  get; private set; }

    //스와코 탄알 발사하는 곳 위치
    public Transform bullet0Fire { get; private set; }

    //좌우 이동 변수
    float _xORy = 5;
    //전방으로 점프 변수
    float _frontJumpPower = 5;
    //날아다니는 파워
    float _flyingPower = 2;
    //점프 파워
    float _jumpPower = 10;

    //낙하 중 순간들
    public int falling { get; set; }

    //공용 좌우 활용
    public int RiORLe { get; set; }

    //프로퍼티들
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


    //상태 변환
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

        //움직임 상태 스크립트들
        idleState = new SuwakoIdleState();
        walkFrontState = new SuwakoWalkFrontState();
        flyingState = new SuwakoFlyingState();
        jumpingState = new SuwakoJumpingState();
        fallingState = new SuwakoFallingState();

        //스킬 상태 스크립트들
        skill0_ShootingBullet = new SuwakoSkill0_ShootingBullet();


        //상태 스타트문
        ChangeState(idleState);
    }

    void Update()
    {
        //상태 Update
        currentState.Update(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //상태 OnCollisionEnter2D
        currentState.OnCollisionEnter2D(this, collision);
    }

    void FixedUpdate()
    {
        //상태 FixUpdate
        currentState.FixUpdate(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit2D(this, collision);
    }
}
