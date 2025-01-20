using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SuwakoBullet1Controller : MonoBehaviour
{
    int bulletNum = 1;
    SuwakoBulletPool pool;
    string[] excludedTags = { "Bullet", "Monster", "Untagged" };

    private void Start()
    {
        pool = SuwakoBulletPool.bulletPoolInstace;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!excludedTags.Contains(collision.tag))
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
