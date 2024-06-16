using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image playerBar;
    public Image enemyBar; // 敌人血条

    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth; // 单个敌人的血量组件

    private GameObject player;
    private GameObject enemy; // 单个敌人对象

    private float maxHealth = 100;
    private float _lerpSpeed = 3;

    private void Start()
    {
        // 查找玩家对象
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player object with tag 'Player' not found in the scene.");
            return; // 如果没有找到 Player 对象，停止进一步执行
        }

        // 获取 PlayerHealth 组件
        playerHealth = player.GetComponent<PlayerHealth>();

        // 初始化血条的健康值和最大健康值
        UpdateHealthBar();

        // 查找带有 "Enemy" 标签的单个敌人对象
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null)
        {
            Debug.LogWarning("No enemy object with tag 'Enemy' found in the scene.");
            enemyBar.gameObject.SetActive(false); // 如果没有找到敌人对象，隐藏敌人血条
        }
        else
        {
            // 获取 EnemyHealth 组件
            enemyHealth = enemy.GetComponent<EnemyHealth>();
        }
    }

    private void Update()
    {
        // 持续更新血条显示
        BarFiller();
    }

    private void BarFiller()
    {
        // 使用 Lerp 平滑过渡玩家血条的填充效果
        if (playerHealth != null)
        {
            playerBar.fillAmount = Mathf.Lerp(playerBar.fillAmount, playerHealth.currentHealth / playerHealth.maxHealth, _lerpSpeed * Time.deltaTime);
        }

        // 更新单个敌人血条的填充效果
        if (enemyHealth != null)
        {
            enemyBar.fillAmount = Mathf.Lerp(enemyBar.fillAmount, enemyHealth.currentHealth / enemyHealth.maxHealth, _lerpSpeed * Time.deltaTime);
        }
    }

    private void UpdateHealthBar()
    {
        // 更新玩家的血量和最大血量
        playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            maxHealth = playerHealth.maxHealth;
        }

        // 更新敌人的血量和最大血量
        if (enemy != null)
        {
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                maxHealth = Mathf.Max(maxHealth, enemyHealth.maxHealth);
            }
        }
    }
}
