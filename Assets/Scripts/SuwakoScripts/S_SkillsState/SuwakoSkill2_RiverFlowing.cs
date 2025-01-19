using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuwakoSkill2_RiverFlowing : SuwakoState
{
    //���° �Ѿ��� ��� �� ������ ����
    int bulletNum = 3;
    //������Ʈ Ǯ��
    SuwakoBulletPool pool;

    //�߻���� ��ġ
    Transform startTransform;
    //���� ���� ��ġ
    Transform targetTransform;
    float speed = 20;

    //�ڷ�ƾ ĳ��
    WaitForSeconds delay = new WaitForSeconds(0.8f);

    public override void Enter(SuwakoController suwako)
    {
        suwako.StartCoroutine(ShootBulletSkill2(suwako));
        pool = SuwakoBulletPool.bulletPoolInstace;


        //������ �ִϸ��̼� IsRiverSkill
        suwako.animator.SetInteger("IsRiverSkill", 1);

        //suwako.StopCoroutine(ShootBulletSkill0(suwako));
    }

    public void MoveToAttack(GameObject bullet)
    {
        Vector2 direction = (targetTransform.position - startTransform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    IEnumerator ShootBulletSkill2(SuwakoController suwako)
    {
        while (true)
        {
            yield return delay;
            // Ǯ���� ������Ʈ ��������
            for (int i = 0; i < 7; i++)
            {
                //��ǥ��
                startTransform = suwako.gameObject.transform.GetChild(6);
                targetTransform = suwako.gameObject.transform.GetChild(6).transform.GetChild(0);

                //������ƮǮ������ �Ѿ� ����
                GameObject bullet = pool.GetObject(bulletNum);
                bullet.transform.position = startTransform.position;

                MoveToAttack(bullet);
            }
        }
    }
}
