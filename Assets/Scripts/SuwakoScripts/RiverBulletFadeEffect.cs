using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverBulletFadeEffect : MonoBehaviour
{
    [SerializeField]
    float duration = 1f; // ���������� �� �ɸ��� �ð�

    private Renderer[] childRenderers; // ��� �ڽ��� Renderer �迭

    void Start()
    {
        // �ڽ� ������Ʈ�� Renderer ������Ʈ�� ��� ��������
        childRenderers = GetComponentsInChildren<Renderer>();

        // ��� �ڽ� ������Ʈ�� ������ �ʱ�ȭ
        foreach (var renderer in childRenderers)
        {
            Color startColor = renderer.material.color;
            startColor.a = 0f; // ���İ�(����)�� 0���� ����
            renderer.material.color = startColor;
        }

        // �ڷ�ƾ ����
        StartCoroutine(FadeIn(duration));
    }

    IEnumerator FadeIn(float time)
    {
        float elapsedTime = 0f;

        // �ʱ� ����� ��ǥ ������ ���� ����
        Dictionary<Renderer, Color> initialColors = new Dictionary<Renderer, Color>();
        Dictionary<Renderer, Color> targetColors = new Dictionary<Renderer, Color>();

        foreach (var renderer in childRenderers)
        {
            // �ʱ� ���� ����
            initialColors[renderer] = renderer.material.color;

            // ��ǥ ���� ���� �� ���İ� ����
            Color targetColor = renderer.material.color;
            targetColor.a = 1f; // ���İ� 1�� ����
            targetColors[renderer] = targetColor;
        }

        while (elapsedTime < time)
        {
            float t = elapsedTime / time; // ���� ��� (0 ~ 1)

            // ��� Renderer�� ������ ���� �������� ����
            foreach (var renderer in childRenderers)
            {
                renderer.material.color = Color.Lerp(initialColors[renderer], targetColors[renderer], t);
            }

            elapsedTime += Time.deltaTime; // �ð� ����
            yield return null; // ���� �����ӱ��� ���
        }

        // ��� Renderer�� ���� ���� ����
        foreach (var renderer in childRenderers)
        {
            renderer.material.color = targetColors[renderer];
        }
    }

}
