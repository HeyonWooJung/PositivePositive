using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class SuwakoSkill0_ShootingBullet : SuwakoState
{
    //���° �Ѿ��� ��� �� ������ ����
    int bulletNum = 0;
    //������Ʈ Ǯ��
    SuwakoBulletPool pool;

    //�߻���� ��ġ
    Transform startTransform;
    //���� ���� ��ġ
    Transform targetTransform;
    float speedPower = 10;

    //�� �߻� ������
    int angle = 10;
    bool changeState = false;

    public override void Enter(SuwakoController suwako)
    {
        //������ �ִϸ��̼� attackCa����
        suwako.animator.SetInteger("IsSkills", 1);
        pool = SuwakoBulletPool.bulletPoolInstace;

        angle = 10;
        changeState = false;
    }

    public override void Update(SuwakoController suwako)
    {
        if (changeState == true && suwako.isSkill0End == false)
        {
            suwako.ChangeState(suwako.landingState);
        }
        else if (suwako.isSkill0End == true && changeState == false)
        {
            ShootBulletSkill0(suwako);
        }
    }

    public void MoveToAttack(GameObject bullet)
    {
        Vector2 direction = (targetTransform.position - startTransform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().AddForce(direction * speedPower, ForceMode2D.Impulse);
    }

    public void ShootBulletSkill0(SuwakoController suwako)
    {
        for (int i = 0; i < 16; i++)
        {
            //��ǥ��
            startTransform = suwako.gameObject.transform.GetChild(4);
            targetTransform = suwako.gameObject.transform.GetChild(4).transform.GetChild(0);

            //������ƮǮ������ �Ѿ� ����
            GameObject bullet = pool.GetObject(bulletNum);
            bullet.transform.position = startTransform.position;
            if (suwako.RiORLe == -1)
            {
                startTransform.rotation = Quaternion.Euler(0, 0, (i * angle) - 50);
            }
            else if (suwako.RiORLe == 1)
            {
                startTransform.rotation = Quaternion.Euler(0, 0, -(i * angle) + 50);
            }
            else 
            {
                startTransform.rotation = Quaternion.Euler(0, 0, (i * angle) - 50);
            }
            MoveToAttack(bullet);
        }
        changeState = true;
    }
}
