using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuController : MonoBehaviour
{
    public float speed = 5f; // �ƶ��ٶ�
    public float smoothTime = 0.1f; // ƽ��ʱ��

    private Vector3 targetPosition; // Ŀ��λ��

    // Update is called once per frame
    void Update()
    {
        // ��ȡ���λ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // ����Ŀ��λ��Ϊ���λ��
        targetPosition = mousePosition;

        // ��ֵ�ƶ�
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * speed * Time.deltaTime);
    }
}
