using UnityEngine;
using DanmakU;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;   // 最大血量
    public int currentHealth = 0;     // 当前血量
    public int healthChangeAmount = 10; // 每次变化的血量

    void Start()
    {
        currentHealth = maxHealth; // 初始化时设置当前血量为最大血量
    }

    // 增加血量的方法
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;   // 增加当前血量
        if (currentHealth > maxHealth) // 确保当前血量不超过最大血量
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Health increased. Current Health: " + currentHealth);
    }

    // 减少血量的方法
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;   // 减少当前血量
        if (currentHealth < 0) // 确保当前血量不低于 0
        {
            currentHealth = 0;
        }
        Debug.Log("Health decreased. Current Health: " + currentHealth);
    }



    // 碰撞检测方法
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hp_add")) // 检查碰撞对象的标签是否为 "Hp_add"
        {
            IncreaseHealth(healthChangeAmount); // 增加血量
        }
        else if (other.CompareTag("Hp_sub")) // 检查碰撞对象的标签是否为 "Hp_sub"
        {
            DecreaseHealth(healthChangeAmount); // 减少血量
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hp_sub"))
        {
            DecreaseHealth(healthChangeAmount);
        }
    }

}
