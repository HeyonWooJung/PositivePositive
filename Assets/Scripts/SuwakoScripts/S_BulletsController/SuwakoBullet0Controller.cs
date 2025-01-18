using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuwakoBullet0Controller : MonoBehaviour
{
    int bulletNum = 0;
    SuwakoBulletPool pool;
    private void Start()
    {
        pool = SuwakoBulletPool.bulletPoolInstace;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bullet")
        {
            OnBulletDestroy(gameObject);
        }
    }

    public void OnBulletDestroy(GameObject bullet)
    {
        // ������Ʈ Ǯ�� ��ȯ
        pool.ReturnObject(bullet, bulletNum);
    }
}
