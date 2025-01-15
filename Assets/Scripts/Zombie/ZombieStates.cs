using Unity.Mathematics;
using UnityEngine;

// 모든 상태가 State를 들고 있지만 , 하나의 State를 공유하는것이 아닌 각각의 State를 들고 있음
abstract public class State
{
    public float deltaTime { get; set; }
    public int randDirect { get; set; }
    //public Transform target;
    //public Vector2 zombie.mosterToPlayer;
    abstract public void Enter(ZombieController zombie);
    virtual public void OnTriggerEnter2D(ZombieController zombie, Collider2D collision) { }
    virtual public void Update(ZombieController zombie) { }
    virtual public void FixUpdate(ZombieController zombie) { }
}

public class Defalut : State
{
    public override void Enter(ZombieController zombie)
    {
        zombie.Animator.SetBool("IsWalk", false);
        zombie.Rigid.velocity = Vector3.zero;
        zombie.directionX = 0;
        zombie.directionY = 0;
        randDirect = UnityEngine.Random.Range(0,1);
    }
    public override void Update(ZombieController zombie)
    {
        deltaTime += Time.deltaTime;
        //FindPlayer(zombie);
        //Debug.Log("x : " + zombie.playerInfo.transform.position.x +", y : " + zombie.playerInfo.transform.position.y);
        if (deltaTime >5)
        {
            deltaTime = -1000000000;
            var temp = GameObject.Instantiate(zombie.WormShieldPrefab,zombie.transform.position,zombie.transform.rotation);
            temp.GetComponent<WormRotation>().zombieInfo=zombie.gameObject;
        }
        // zombie.ChangeState(zombie.jumpReady);

        //if (deltaTime >= 3)
        //{
        //    deltaTime = 0;
        //    zombie.ChangeState(zombie.walk);
        //}
    }

    //void FindPlayer(ZombieController zombie)
    //{
    //    Collider2D player;
    //    player = Physics2D.OverlapCircle(zombie.transform.position, 100.0f, zombie.playerLayer);
    //    if (player != null)
    //    {
    //        //zombie.target = player.transform; 
    //        target = player.transform; 
    //    }
    //}
}

public class Walk : State
{
    int maxRandNum = 100;
    int leftRange = 25;
    int rightRange =50;
    int upRange = 75;
    int downRange = 100;
    int increaseRange = 0;

   
    public override void OnTriggerEnter2D(ZombieController zombie, Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
         DirectionChangeWall(zombie);
        }
    }
    public override void Enter(ZombieController zombie)
    {
        zombie.Animator.SetBool("IsWalk", true);
        RandomMoveRange(zombie);
    }
   
    public override void Update(ZombieController zombie)
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 4)
        {
            deltaTime = 0;
            zombie.ChangeState(zombie.defalut);
        }
    }

    public override void FixUpdate(ZombieController zombie)
    {
        DirectionAddForce(zombie);
        DirectionRotation(zombie);
       
    }
    void ResetDiectionRange()
    {
        maxRandNum = 100;
        leftRange = 25;
        rightRange = 50;
        upRange = 75;
        downRange = 100;
        increaseRange = 0;
    }
    void DirectionChangeWall(ZombieController zombie)
    {
        zombie.directionX *= -1;
        zombie.directionY *= -1;
    }
    void DirectionAddForce(ZombieController zombie)
    {
        if (zombie.directionX == -1 || zombie.directionX == 1)
        {
            zombie.Rigid.velocity = new Vector2(2.0f * zombie.directionX, 0);
        }
        if (zombie.directionY == 1 || zombie.directionY == -1)
        {
            zombie.Rigid.velocity = new Vector2(0, 2.0f * zombie.directionY);
        }
    }
    void DirectionRotation(ZombieController zombie)
    {
        if (zombie.directionX == -1)
        {
            zombie.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (zombie.directionX == 1)
        {
            zombie.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (zombie.directionY == 1)
        {
            zombie.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (zombie.directionY == -1)
        {
            zombie.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
    void RandomMoveRange(ZombieController zombie)
    {
        randDirect = UnityEngine.Random.Range(0, maxRandNum + increaseRange);
        if (0 < randDirect && randDirect < leftRange)
        {
            zombie.directionX = -1;
            leftRange -= 5;
        }
        else if (leftRange < randDirect && randDirect < rightRange)
        {
            zombie.directionX = 1;
            rightRange -= 5;
        }
        else if (rightRange < randDirect && randDirect < upRange)
        {
            zombie.directionY = 1;
            upRange -= 5;
        }
        else if (upRange < randDirect && randDirect < downRange)
        {
            zombie.directionY = -1;
            downRange -= 5;
        }
        increaseRange -= 5;
        if (rightRange == 0 || leftRange == 0 || downRange == 0 || upRange == 0)
        {
            ResetDiectionRange();
        }
    }
}

public class JumpReady : State
{
    public override void Enter(ZombieController zombie)
    {
        //zombie.setActive.SetActiveTrue();
        //Debug.Log("x : " + zombie.playerInfo.transform.position.x + ", y : " + zombie.playerInfo.transform.position.y);
        zombie.Animator.SetTrigger("JumpReady");
        zombie.mosterToPlayer = zombie.PlayerInfo.transform.position - zombie.transform.position;
        // 벡터 크기 1로
        zombie.mosterToPlayer.Normalize();
        // 180도 더한 이유 - 유니티 내 좌표계에서 시계방향으로 각도회전을 하는데, 그것을 이용해 내 이미지의 기준인 180도를 더해주었다.
        zombie.transform.rotation = Quaternion.Euler(0, 0,180 + Mathf.Atan2(zombie.mosterToPlayer.y, zombie.mosterToPlayer.x) * Mathf.Rad2Deg);
    }
    public override void Update(ZombieController zombie)
    {
        if (zombie.jumpOn == true)
        {
            zombie.ChangeState(zombie.jump);
        }
    }

}
public class Jump : State
{
    public override void Enter(ZombieController zombie)
    {
        //zombie.setActive.SetActiveFalse();
        zombie.Animator.SetBool("IsJump", true);
    }
    public override void Update(ZombieController zombie)
    {
    }
    public override void FixUpdate(ZombieController zombie)
    {
        zombie.Rigid.velocity = zombie.mosterToPlayer * 10;
    }
    public override void OnTriggerEnter2D(ZombieController zombie,Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            zombie.Animator.SetBool("IsJump", false);
            zombie.ChangeState(zombie.defalut);
        }
    }

}


