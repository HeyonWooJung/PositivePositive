using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class SuwakoSkill1_JumpORFlyShootingBullet : SuwakoState
{
    //���° �Ѿ��� ��� �� ������ ����
    int bulletNum = 1;
    //������Ʈ Ǯ��
    SuwakoBulletPool pool;

    //�θ�ü�� ��ġ
    Transform parentTransform;
    //�ڽİ�ü�� ��ġ
    Transform childTransform;
    float speedPower = 10;

    //�� �߻� ������
    int angle = 10;
    bool changeState = false;

    int count;

    public override void Enter(SuwakoController suwako)
    {
        suwako.animator.SetInteger("IsSkills", 2);
        pool = SuwakoBulletPool.bulletPoolInstace;
        angle = 10;
        changeState = false;
        count = 0;

        suwako.StartCoroutine(ShootBulletSkill1(suwako));
    }

    public override void Update(SuwakoController suwako)
    {
        if (changeState == true)
        {
            suwako.ChangeState(suwako.fallingState);
        }
        else if (changeState == false)
        {
            suwako.rb.velocity = new Vector2(0, 0);
        }
    }

    public void MoveToAttack(GameObject bullet)
    {
        Vector2 direction = (childTransform.position - parentTransform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().AddForce(direction * speedPower, ForceMode2D.Impulse);
    }

    IEnumerator ShootBulletSkill1(SuwakoController suwako)
    {
        while (count < 5)
        {
            for (int i = 0; i < 36; i++)
            {
                
                //��ǥ��
                parentTransform = suwako.gameObject.transform.GetChild(5);
                childTransform = suwako.gameObject.transform.GetChild(5).transform.GetChild(0);

                //������ƮǮ������ �Ѿ� ����
                GameObject bullet = pool.GetObject(bulletNum);
                bullet.transform.position = childTransform.position;
                parentTransform.rotation = Quaternion.Euler(0, 0, i * angle);

                MoveToAttack(bullet);
            }
            count++;
            yield return new WaitForSeconds(1f); // 1�� ���
        }
        changeState = true;
    }
}
