using UnityEngine;

public class DropItem : MonoBehaviour
{
    public float downSpeed = 3f; // 向下移动的速度
    public float lifeTime = 30f; // 掉落物的存在时间

    private Rigidbody2D rb;
    private Vector2 downVelocity; // 向下的速度

    void Start()
    {
        // 获取 Rigidbody2D 组件
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on drop game object.");
            return;
        }

        // 设置向下的速度
        downVelocity = Vector2.down * downSpeed;
        rb.velocity = downVelocity;

        // 设置掉落物的存在时间
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 确保物体一直向下移动
        if (rb != null)
        {
            rb.velocity = downVelocity;
        }
    }

    // 当掉落物进入触发器区域时调用
    void OnTriggerExit2D(Collider2D other)
    {
        // 检查碰撞体是否具有特定标签或组件
        if (other.CompareTag("Finish")) // 用实际的标签替换 "TargetTag"
        {
            Destroy(gameObject); // 销毁掉落物
        }
    }

    // 当掉落物在触发器区域内停留时调用（可选）
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Player")) // 用实际的标签替换 "TargetTag"
        {
            Destroy(gameObject); // 销毁掉落物
        }
    }

    // 当掉落物退出触发器区域时调用（可选）

}
