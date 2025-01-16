using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuwakoWalkFrontState : SuwakoState
{
    public override void Enter(SuwakoController suwako)
    {
        suwako.animator.SetTrigger("IsWalkFront");
        suwako.RiORLe = Random.Range(0, 2) == 0 ? -1 : 1;
        //�������� �·�
        if (suwako.RiORLe == -1)
        {
            suwako.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        //�������� ���
        else if (suwako.RiORLe == 1)
        {
            suwako.transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        suwako.rb.AddForce(new Vector2(suwako.RiORLe * suwako.xORy, suwako.frontJumpPower), ForceMode2D.Impulse);
    }
    public override void Update(SuwakoController suwako)
    {
        if(suwako.rb.velocity.y < 0)
        {
            suwako.ChangeState(suwako.fallingState);
        }
    }
    public override void FixUpdate(SuwakoController suwako) { }
    public override void OnCollisionEnter2D(SuwakoController suwako, Collision2D collision) { }
    public override void OnTriggerEnter2D(SuwakoController suwako, Collider2D collider) { }
    public override void OnTriggerExit2D(SuwakoController suwako, Collider2D collider) { }
}
