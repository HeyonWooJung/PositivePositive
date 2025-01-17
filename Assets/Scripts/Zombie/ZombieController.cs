﻿using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class ZombieController : MonoBehaviour
{
    public Collider2D zombieCollider;
    Animator animator;
    Rigidbody2D rigid;
    ZombieState zombieState;
    public ZombieObjectPooling zomObjPool { get; set; }
    [SerializeField] GameObject playerInfo;
    [SerializeField] GameObject jumpSkillRange;
    [SerializeField] GameObject blackHoleSkillPrepeb;
    
    public GameObject BlackHoleSkillPrepeb
    {
        get
        {
            return blackHoleSkillPrepeb;
        }
    }

    //public GameObject WormShieldPrefab
    //{
    //    get
    //    {
    //        return wormShieldPrefab;
    //    }
    //    set
    //    {
    //        wormShieldPrefab = value;
    //    }
    //}
    public GameObject PlayerInfo
    {
        get
        {
            return playerInfo;
        }
    }
    public GameObject JumpSkillRange
    {
        get
        {
            return jumpSkillRange;
        }
        set
        {
            jumpSkillRange = value;
        }
    }

    public short directionX { get; set; }
    public short directionY { get; set; }
    // ______________ 상태 ___________________
    public ZombieSkillBlackHole skillBlackHole { get; private set; }
    public ZombieJump jump { get; private set; }
    public ZombieJumpReady jumpReady { get; private set; } 
    public ZombieWalk walk { get; private set; }
    public ZombieIdle idle { get; private set; }
    // ___________ 컴포넌트 _____________________
    public Animator Animator { get { return animator; } }
    public Rigidbody2D Rigid { get { return rigid; } }
    // ___________ 점프 기능 _____________________
    public float distance { get; set; }
    public RaycastHit2D ray2d { get; set; }
    public Vector2 mapBounds { get; set; }
    public Vector2 mosterToPlayer;
    public bool jumpOn=false;
    // ______________ 스킬 1 WormShield ___________________

    public int wormMaxCount { get; set; }
    public int wormHaveCount{ get; set; }
    public bool wormCreated { get; set; }
    


    public float deltaTime { get; set; }
    public int randState;
    public int randDirect;


    public void ChangeState(ZombieState newState)
    {
        zombieState = newState;
        zombieState.Enter(this);
        deltaTime = 0;
    }
    void Start()
    {
        zomObjPool = gameObject.GetComponent<ZombieObjectPooling>();
        wormHaveCount = 0;
        wormMaxCount = 4;

        distance = 100f;
        //______________________
        jump = new ZombieJump();
        jumpReady = new ZombieJumpReady();
        walk = new ZombieWalk();
        idle = new ZombieIdle();
        skillBlackHole = new ZombieSkillBlackHole();
        //_____________________
        zombieCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        zomObjPool.CreatObject();
        ChangeState(idle);
    }

    void Update()
    {
        if (zombieState != null)
        {
            zombieState.Update(this);
        }
    }

    private void FixedUpdate()
    {
        if (zombieState != null)
        {
            zombieState.FixUpdate(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (zombieState != null)
        {
            zombieState.OnCollisionEnter2D(this, collision);
        }

    }
    public void CorutinPlay(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

}
