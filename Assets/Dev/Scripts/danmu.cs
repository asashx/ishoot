using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class danmu : MonoBehaviour
{
    private System.Random ran; // 使用 System.Random
    private float n; // 将 n 声明为 float 类型

    public float speed = 2;
    public Transform thisTransform;

    void Start()
    {
        ran = new System.Random(); // 实例化 ran
        thisTransform = this.gameObject.transform;
        n = ran.Next(10); // 获取随机数
    }

    void Update()
    {
        thisTransform.position = new Vector3(thisTransform.position.x + n * Time.deltaTime, 
                                              thisTransform.position.y + speed * Time.deltaTime,
                                              thisTransform.position.z);
    }
}