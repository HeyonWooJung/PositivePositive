using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WormRotation : MonoBehaviour
{
    public GameObject zombieInfo;
    public ZombieObjectPooling objectPool;
    // ������
    float radius;
    // �� ���ǵ�
    float rotationSpeed;
    // ����
    float angle;
    // Worm�� Worm ������ ����
    public float angleX;
    public float angleY;
    public int num;
    void Start()
    {
        radius = 5f;
        rotationSpeed = 50f;
    }

    void Update()
    {
        angle += Time.deltaTime * rotationSpeed;
        //angle %= 360;
        float ran = angle * Mathf.Deg2Rad;
        angleX = zombieInfo.transform.position.x + (radius * Mathf.Cos(ran));
        angleY = zombieInfo.transform.position.y + (radius * Mathf.Sin(ran));
        transform.position = new Vector3(angleX, angleY, 0);
    }

    public void CreatWormShield(int i)
    {
        angle = 360 - (90 *i);
        float ran = angle * Mathf.Deg2Rad;
        angleX = zombieInfo.transform.position.x + (radius * Mathf.Cos(ran));
        angleY = zombieInfo.transform.position.y + (radius * Mathf.Sin(ran));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� ������ ��������� �ٲ�� ��
        if (collision.gameObject.tag == "Wall")
        {
            OnWormDestroy(gameObject);
        }
    }

    public void OnWormDestroy(GameObject wormShield)
    {
        // ������Ʈ Ǯ�� ��ȯ
         objectPool.ReturnObject(wormShield);
    }

}