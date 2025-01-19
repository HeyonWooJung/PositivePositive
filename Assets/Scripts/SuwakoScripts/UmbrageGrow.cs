using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrageGrow : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(10f, 10f, 10f); // ���� ũ��
    public float duration = 1f; // Ŀ���� �� �ɸ��� �ð�

    void Start()
    {
        StartCoroutine(ScaleOverTime(targetScale, duration));
    }

    IEnumerator ScaleOverTime(Vector3 target, float time)
    {
        Vector3 initialScale = transform.localScale; // ���� ũ��
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            // ���� �ð� ���� ���
            float t = elapsedTime / time;

            // ���� �������� ũ�� ����
            transform.localScale = Vector3.Lerp(initialScale, target, t);

            elapsedTime += Time.deltaTime; // �ð� ����
            yield return null; // ���� �����ӱ��� ���
        }

        // ���� ũ�� ���� (���е� ���� ����)
        transform.localScale = target;
    }
}
