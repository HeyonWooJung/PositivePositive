using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public GameObject aa;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ʈ���� �ߵ�");
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.transform.GetComponentInParent<BoxCollider2D>() == null)
            {
                Debug.Log("�γ�");
            }
            // �̰� ��ã�ƿ�
            transform.GetComponentInParent<BoxCollider2D>().isTrigger = true; 
            // �̰� ã�ƿ�
            aa.GetComponentInParent<BoxCollider2D>().isTrigger = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //transform.GetComponentInParent<BoxCollider2D>().isTrigger = true; 
            aa.GetComponentInParent<BoxCollider2D>().isTrigger = false;
        }
    }
}
