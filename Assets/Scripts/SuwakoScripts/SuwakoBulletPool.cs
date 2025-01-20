using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuwakoBulletPool : MonoBehaviour
{
    public static SuwakoBulletPool bulletPoolInstace;

    [SerializeField]
    public GameObject[] bullets; // ������ ������

    //Ǯ����ҵ� �����鿡 ���� ���� �ø��� �ֵ��� �����ؾ���.
    private Queue<GameObject>[] pools; // Ǯ �����

    private void Start()
    {
        bulletPoolInstace = this;

        pools = new Queue<GameObject>[bullets.Length];

        for (int i = 0; i < bullets.Length; i++)
        {
            // �� ť �ʱ�ȭ
            pools[i] = new Queue<GameObject>();
        }

        //�� 100���� ����� ���ÿ�, Ǯ ����ҿ� �ִ´�.
        for (int i = 0; i < 100; i++)
        {
            for(int bulletNums = 0; bulletNums < bullets.Length; bulletNums++)
            {
                var t = Instantiate(bullets[bulletNums]);
                t.SetActive(false);
                pools[bulletNums].Enqueue(t);
            }
        }
    }

    // Ǯ���� ������Ʈ ��������
    public GameObject GetObject(int bulletNum)
    {
        if (pools[bulletNum].Count > 0)
        {
            var obj = pools[bulletNum].Dequeue();
            obj.SetActive(true); // ������Ʈ Ȱ��ȭ
            return obj;
        }

        // Ǯ�� ������Ʈ�� ������ ���� ����
        return Instantiate(bullets[bulletNum]);
    }

    // ������Ʈ Ǯ�� ��ȯ�ϱ�
    public void ReturnObject(GameObject obj, int k)
    {
        obj.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        pools[k].Enqueue(obj); // Ǯ�� ��ȯ
    }
}
