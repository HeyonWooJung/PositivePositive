using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuwakoBulletObjectPool : MonoBehaviour
{
    public GameObject prefab; // ������ ������

    [SerializeField]

    private Queue<GameObject> pool = new Queue<GameObject>(); // Ǯ �����

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
        return Instantiate(prefab);
    }

    // ������Ʈ Ǯ�� ��ȯ�ϱ�
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        pool.Enqueue(obj); // Ǯ�� ��ȯ
    }
}
