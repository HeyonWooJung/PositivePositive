using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RotationCircle : MonoBehaviour
{
    
    public GameObject centerRotation { get; set; }
    //public ZombieObjectPooling objectPool;
    // ������
    public float radius { get; set; }
    // �� ���ǵ�
    public float rotationSpeed { get; set; }
    // ����
    float angle;
    // Worm�� Worm ������ ����
    public float angleX;
    public float angleY;
    public int num;
    void Update()
    {
        angle += Time.deltaTime * rotationSpeed;
        //angle %= 360;
        float ran = angle * Mathf.Deg2Rad;
        angleX = centerRotation.transform.position.x + (radius * Mathf.Cos(ran));
        angleY = centerRotation.transform.position.y + (radius * Mathf.Sin(ran));
        transform.position = new Vector3(angleX, angleY, 0);
    }

    public void CreatWormShield(int i)
    {
        angle = 360 - (90 *i);
        float ran = angle * Mathf.Deg2Rad;
        angleX = centerRotation.transform.position.x + (radius * Mathf.Cos(ran));
        angleY = centerRotation.transform.position.y + (radius * Mathf.Sin(ran));
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // �÷��̾� ������ ��������� �ٲ�� ��
    //    if (collision.gameObject.tag == "Wall")
    //    {
    //        OnWormDestroy(gameObject);
    //    }
    //}

    //public void OnWormDestroy(GameObject wormShield)
    //{
    //    // ������Ʈ Ǯ�� ��ȯ
    //     objectPool.ReturnObject(wormShield);
    //}

}