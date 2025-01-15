using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    bool isIdle = true;
    float idleTime = 0;

    //���� ���� �ص� ��.
    int whatState = 0;

    public override void Enter(SuwakoController suwako)
    {
        suwako.animator.SetBool("IsIdle", true);

        //idle ���� 3�ʰ� ������ ���� ��
        idleTime = Time.time + 3;
        whatState = 0;
        isIdle = false;
    }
    public override void Update(SuwakoController suwako)
    {
        if (isIdle == true)
        {
            //���¸� ���������� ������
            whatState = Random.Range(0, 4);
        }

        if (whatState == 0)
        {
            if (Time.time >= idleTime)
            {
                isIdle = true;
            }
        }
        else if (whatState == 1)
        {
            //�¿�� �̵��ϴ� ����
            suwako.ChangeState(suwako.walkFrontState);
        }
        else if (whatState == 2)
        {
            //���� ������ ����
            suwako.ChangeState(suwako.flyingState);
        }
        else if (whatState == 3)
        {
            //������ ����
            suwako.ChangeState(suwako.jumpingState);
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
