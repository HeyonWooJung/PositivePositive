using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuwakoFlyingState : SuwakoState
{
    int flyingState = 0;
    float flyingTime = 0;
    bool isCorret = false;

    public override void Enter(SuwakoController suwako)
    {
        suwako.RiORLe = Random.Range(0, 2) == 0 ? -1 : 1;
        suwako.animator.SetInteger("IsFlying", 1);
        flyingTime = Time.time + 5;
        flyingState = 0;
    }
    public override void Update(SuwakoController suwako)
    {
        if (Time.time < flyingTime)
        {
            isCorret = true;
        }
        else
        {
            isCorret = false;
        }

        //���� �ִ� ���̸�
        if (flyingState == 0)
        {
            suwako.animator.SetInteger("IsFlying", 2);
        }
        //���� ���� ������
        else if (flyingState == 1)
        {
            suwako.animator.SetInteger("IsFlying", 3);

            suwako.ChangeState(suwako.fallingState);
        }
    }
    public override void FixUpdate(SuwakoController suwako)
    {
        //5�ʵ��� ���� �Ǵٰ� 5�ʰ� ������ ��ž
        if (isCorret == true)
        {
            flyingState = 0;

            if (suwako.RiORLe == -1)
            {
                suwako.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (suwako.RiORLe == 1)
            {
                suwako.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            suwako.rb.velocity = new Vector2(suwako.RiORLe, suwako.flyingPower);
        }
        else
        {
            flyingState = 1;
        }
    }
    public override void OnCollisionEnter2D(SuwakoController suwako, Collision2D collision) { }
    public override void OnTriggerEnter2D(SuwakoController suwako, Collider2D collider) { }
    public override void OnTriggerExit2D(SuwakoController suwako, Collider2D collider) { }
}
