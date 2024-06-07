using UnityEngine;

public class DropItemHealthIncrease : MonoBehaviour
{
    public int healthIncreaseAmount = 20; // 增加的血量数值

    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞体是否具有玩家标签
        if (other.CompareTag("Player")) // 确保玩家对象的标签是 "Player"
        {
            // 获取玩家对象上的 PlayerHealth 组件
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // 增加玩家的血量
                playerHealth.IncreaseHealth(healthIncreaseAmount);
            }
            // 销毁掉落物
            Destroy(gameObject);
        }
    }
}
