
using UnityEngine;

public class ZombieJumpReady : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.Animator.SetTrigger("JumpReady");
        zombie.mosterToPlayer = zombie.PlayerInfo.transform.position - zombie.transform.position;
        // 180�� ���� ���� - ����Ƽ �� ��ǥ�迡�� �ð�������� ����ȸ���� �ϴµ�, �װ��� �̿��� �� �̹����� ������ 180���� �����־���.
        zombie.transform.rotation = Quaternion.Euler(0, 0, 180 + Mathf.Atan2(zombie.mosterToPlayer.y, zombie.mosterToPlayer.x) * Mathf.Rad2Deg);
        // ���� ũ�� 1��
        zombie.mosterToPlayer.Normalize();
        PrintJumpRange(zombie);
    }
    public override void Update(ZombieController zombie)
    {
        Debug.DrawRay(zombie.transform.position, zombie.mosterToPlayer * zombie.distance, Color.green);
        if (zombie.jumpOn == true)
        {
            zombie.jumpOn = false;
            zombie.ChangeState(zombie.jump);
        }
    }
    public void PrintJumpRange(ZombieController zombie)
    {
        // ���� ĳ��Ʈ�� ��Ÿ� �� (��) ��ǥ ���ϱ�
        zombie.ray2d = Physics2D.Raycast(zombie.transform.position, zombie.mosterToPlayer, zombie.distance, LayerMask.GetMask("Wall"));
        if (zombie.ray2d == true)
        {
            zombie.mapBounds = zombie.ray2d.point;
        }
        // ���� ��ġ�� ��Ÿ� �� ������ �Ÿ� ����
        float distance = Vector2.Distance(zombie.mapBounds, zombie.transform.position);
        // ���̿� ���� ���� �����ֱ�
        float length = distance / 10;
        // ��Ÿ� �ڽ� ���� �÷��ֱ�
        zombie.JumpSkillRange.transform.localScale = new Vector3(distance / 10, 0.3f, 0);
        // ��Ÿ� �ڽ� �߽� ��ǥ �̵��ؼ� �������� �����ֱ�
        zombie.JumpSkillRange.transform.position = new Vector2(zombie.transform.position.x + (length * zombie.mosterToPlayer.x *5), zombie.transform.position.y + (length * zombie.mosterToPlayer.y *5));
        zombie.JumpSkillRange.SetActive(true);

    }

}
public class ZombieJump : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.Animator.SetBool("IsJump", true);
        zombie.JumpSkillRange.SetActive(false);
    }
    public override void Update(ZombieController zombie)
    {
        //zombie.Rigid.AddForce(zombie.mosterToPlayer*10);
    }
    public override void FixUpdate(ZombieController zombie)
    {
        //if (zombie.ray2d.point == (Vector2)zombie.transform.position)
        //{
        //}
        zombie.Rigid.velocity = zombie.mosterToPlayer * 10;
        zombie.deltaTime += Time.deltaTime;
        if (zombie.deltaTime > 2)
        {
            //Debug.Log(zombie.deltaTime);
            zombie.deltaTime = 0;
            zombie.Animator.SetBool("IsJump", false);
            zombie.ChangeState(zombie.idle);
        }
    }
    public override void OnCollisionEnter2D(ZombieController zombie, Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("����");
            // ����ĳ��Ʈ
            // �����Ǿ��ٸ�!
            // if (zombie.ray2d.collider != null)
            // {
            zombie.Animator.SetBool("IsJump", false);
            zombie.ChangeState(zombie.idle);
            // }
        }
    }

}