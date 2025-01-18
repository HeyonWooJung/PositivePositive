using System.Collections.Generic;
using UnityEngine;

public class ZombieObjectPooling : MonoBehaviour
{
    public GameObject wormprefab; // ������ ������
    private Queue<GameObject> pool = new Queue<GameObject>(); // Ǯ �����
    public int poolMaxCount = 4;

    // ������Ʈ ��Ȱ��ȭ �� pool�� ���
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        pool.Enqueue(obj); // Ǯ�� ��ȯ
    }
    /// <summary>
    /// ��� Worm�� �ν��Ͻ�ȭ ��Ű�� ��Ȱ��ȭ
    /// </summary>
    public void CreatObject()
    {
        if (wormprefab == null)
        {
            Debug.Log("null");
        }
        for (int i = 0; i <  poolMaxCount; i++)
        {
            var obj = Instantiate(wormprefab);
            obj.SetActive(false);
            obj.GetComponent<WormRotation>().zombieInfo = gameObject;
            obj.GetComponent<WormRotation>().num = i;
            obj.GetComponent<WormRotation>().objectPool = this;
            //StartSetting(obj, i);
            pool.Enqueue(obj);
        }
    }
    /// <summary>
    /// ��� Worm�� Ȱ��ȭ
    /// </summary>
    public void AllActiveTrue()
    {
           // Debug.Log(pool.Count);    
        if (pool.Count < 4)
        {
            return;
        }
        else if (pool.Count == 4)
        {
            for (int i =0; i< poolMaxCount; i++)
            {
                var obj = pool.Dequeue();
                obj.SetActive(true);
                StartSetting(obj, i);
            }
        }
    }
    /// <summary>
    /// ���� �ֺ��� ���� worm�� 90, 180, 270, 360�� ��ġ�� �����ǰ� �ϴ� �Լ�
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="i"> ���� </param>
    public void StartSetting(GameObject obj, int i)
    {
        obj.GetComponent<WormRotation>().CreatWormShield(i);
        obj.transform.position = new Vector2(obj.GetComponent<WormRotation>().angleX, obj.GetComponent<WormRotation>().angleY);

    }
}
