using System.Collections.Generic;
using UnityEngine;

public class ZombieObjectPooling : MonoBehaviour
{
    public GameObject wormPrefab; // ������ ������
    private Queue<GameObject> pool = new Queue<GameObject>(); // Ǯ �����
    public int poolMaxCount = 6;

    /// <summary>
    /// ������Ʈ ��Ȱ��ȭ �� pool�� ���
    /// </summary>
    /// <param name="obj"></param>
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
        if (wormPrefab == null)
        {
            Debug.Log("null");
        }
        for (int i = 0; i <  poolMaxCount; i++)
        {
            var obj = Instantiate(wormPrefab);
            obj.SetActive(false);
            obj.GetComponent<RotationCircle>().centerRotation = gameObject;
            obj.GetComponent<RotationCircle>().num = i;
            obj.GetComponent<RotationCircle>().radius = 5f;
            obj.GetComponent<RotationCircle>().rotationSpeed = 50f;
            obj.GetComponent<WormController>().objPooling = this;
            //obj.GetComponent<RotationCircle>().objectPool = this;
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
        obj.GetComponent<RotationCircle>().CreatWormShield(i);
        obj.transform.position = new Vector2(obj.GetComponent<RotationCircle>().angleX, obj.GetComponent<RotationCircle>().angleY);

    }
}
