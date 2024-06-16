using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public int healthChangeAmount = 10;

    public bool isInvincible = false; // 添加无敌状态变量

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Health increased. Current Health: " + currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        Debug.Log("Health decreased. Current Health: " + currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hp_add"))
        {
            IncreaseHealth(healthChangeAmount);
        }
        else if (other.CompareTag("Hp_sub"))
        {
            DecreaseHealth(healthChangeAmount);
        }
    }
}
