using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Text buttonText;  // ��ư �̹���
    public Color normalColor; // �⺻ ���� (���)
    public Color highlightedColor; // ���콺 �÷��� �� ���� (���)

    void Start()
    {
        // ��ư�� Image ������Ʈ ��������
        buttonText = transform.GetChild(0).GetComponent<Text>();
        normalColor = Color.black;
        highlightedColor = Color.white;
    }


    // ���� ���� (���콺 �÷��� ��)
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("���콺 �ö�");
        if (buttonText != null)
        {
            buttonText.color = highlightedColor;  // ���� ���� (���)
        }
    }

    // ���� �ǵ����� (���콺 ��� ��)
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("���콺 ������");
        if (buttonText != null)
        {
            buttonText.color = normalColor;  // ���� �������� ���� (���)
        }
    }

}
