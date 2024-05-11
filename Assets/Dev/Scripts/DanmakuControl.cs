using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuController : MonoBehaviour
{
    public float speed = 5f; // 移动速度
    public float smoothTime = 0.1f; // 平滑时间

    private Vector3 targetPosition; // 目标位置

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // 设置目标位置为鼠标位置
        targetPosition = mousePosition;

        // 插值移动
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * speed * Time.deltaTime);
    }
}
