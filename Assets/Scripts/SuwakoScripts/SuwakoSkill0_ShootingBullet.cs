using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SuwakoSkill0_ShootingBullet : SuwakoState
{
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>(); // Ǯ �����

    public override void Enter(SuwakoController suwako)
    {
        prefab = suwako.bullets[0];
        //������ �ִϸ��̼� attackCa����
    }

    public override void Update(SuwakoController suwako)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Ǯ���� ������Ʈ ��������
            GameObject bullet = GetObject();

            //�߻��� ��ġ
            bullet.transform.position = suwako.bullet0Fire.transform.position;
        }
    }

    public void OnBulletDestroy(GameObject bullet)
    {
        // ������Ʈ Ǯ�� ��ȯ
        ReturnObject(bullet);
    }

    
    // Ǯ���� ������Ʈ ��������
    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            var obj = pool.Dequeue();
            obj.SetActive(true); // ������Ʈ Ȱ��ȭ
            return obj;
        }

        // Ǯ�� ������Ʈ�� ������ ���� ����
        return GameObject.Instantiate(prefab);
    }

    // ������Ʈ Ǯ�� ��ȯ�ϱ�
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        pool.Enqueue(obj); // Ǯ�� ��ȯ
    }
}
