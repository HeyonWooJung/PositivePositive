using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuwakoSkill2_RiverFlowing : SuwakoState
{
    ////���° �Ѿ��� ��� �� ������ ����
    //int bulletNum = 0;
    ////������Ʈ Ǯ��
    //SuwakoBulletPool pool;

    ////�߻���� ��ġ
    //Transform startTransform;
    ////���� ���� ��ġ
    //Transform targetTransform;
    //float speed = 10;

    ////�ڷ�ƾ ĳ��
    //WaitForSeconds delay = new WaitForSeconds(0.8f);

    //public override void Enter(SuwakoController suwako)
    //{
    //    suwako.StartCoroutine(ShootBulletSkill0(suwako));

    //    pool = SuwakoBulletPool.bulletPoolInstace;

    //    //������ �ִϸ��̼� attackCa����
    //    suwako.animator.SetTrigger("IsSkill0");

    //    //suwako.StopCoroutine(ShootBulletSkill0(suwako));
    //}

    //public void MoveToAttack(GameObject bullet)
    //{
    //    Vector2 direction = (targetTransform.position - startTransform.position).normalized;
    //    bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
    //}

    //IEnumerator ShootBulletSkill0(SuwakoController suwako)
    //{
    //    while (true)
    //    {
    //        yield return delay;
    //        // Ǯ���� ������Ʈ ��������
    //        for (int i = 0; i < 7; i++)
    //        {
    //            //��ǥ��
    //            startTransform = suwako.gameObject.transform.GetChild(4);
    //            targetTransform = suwako.gameObject.transform.GetChild(4).transform.GetChild(0);

    //            //������ƮǮ������ �Ѿ� ����
    //            GameObject bullet = pool.GetObject(bulletNum);
    //            bullet.transform.position = startTransform.position;
    //            startTransform.rotation = Quaternion.Euler(0, 0, i * 10);

    //            MoveToAttack(bullet);
    //        }
    //    }
    //}
}
