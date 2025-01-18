using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SuwakoIdleState : SuwakoState
{
    bool isIdle = true;
    float idleTime = 0;
    int whatState = 0;

    public override void Enter(SuwakoController suwako)
    {
        suwako.animator.SetInteger("IsSkills", 0);
        suwako.animator.SetInteger("IsFalling", 0);
        suwako.animator.SetBool("IsIdle", true);
        suwako.animator.SetBool("IsLanding", false);

        //idle ���� 3�ʰ� ������ ���� ��
        idleTime = Time.time + 3;
        whatState = 0;

        //false�� �ٽ� �ٲ����.
        isIdle = false;
    }
    public override void Update(SuwakoController suwako)
    {
        if (isIdle == true)
        {
            //���¸� ���������� ������
            whatState = Random.Range(6, 8);
        }

        if (whatState == 0)
        {
            if (Time.time >= idleTime)
            {
                isIdle = true;
            }
        }
        else if (1 <= whatState && whatState <= 4)
        {
            //�¿�� �̵��ϴ� ����
            suwako.ChangeState(suwako.walkFrontState);
        }
        else if (whatState == 5)
        {
            //���� ������ ����
            suwako.ChangeState(suwako.flyingState);
        }
        else if (whatState == 6)
        {
            //������ ����
            suwako.ChangeState(suwako.jumpingState);
        }
        else if(whatState == 7)
        {
            suwako.ChangeState(suwako.skill0_ShootingBullet);
        }
    }

    public override void OnCollisionEnter2D(SuwakoController suwako, Collision2D collision)
    {
        //���� ������ �������� 0���� ���� ��ġ
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            suwako.rb.velocity = new Vector2();
        }
    }
}
