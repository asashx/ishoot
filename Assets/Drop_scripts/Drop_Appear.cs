using UnityEngine;

public class SpawnOnBossDeath : MonoBehaviour
{
    public GameObject prefabToSpawn; // 要生成的预制体
    public int totalNumberOfPrefabsToSpawn = 10; // 总共要生成的预制体数量
    public float spawnInterval = 1f; // 生成间隔时间
    public float spawnRadius = 5f; // 生成半径

    private Transform bossTransform;
    private bool isSpawning = false;
    private int numberOfPrefabsSpawned = 0; // 已生成的预制体数量

    void Start()
    {
        // 获取Boss的位置
        bossTransform = transform; // 假设Boss物体就是脚本所附加的物体
    }

    void Update()
    {
        // 检查触发条件（Boss血量为零）并开始生成预制体
        // if (!isSpawning && BossIsDead())
        if (!isSpawning )
        {
            isSpawning = true;
            InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
        }
    }

    private void SpawnPrefab()
    {
        // 在范围内生成预制体，直到达到总数为止
        if (numberOfPrefabsSpawned < totalNumberOfPrefabsToSpawn)
        {
            // 在范围内随机生成一个位置
            Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
            Vector3 spawnPosition = bossTransform.position + randomOffset;

            // 生成预制体
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // 增加已生成的预制体数量
            numberOfPrefabsSpawned++;
        }
        else
        {
            // 停止生成预制体
            CancelInvoke("SpawnPrefab");
            isSpawning = false;
        }
    }

    // private bool BossIsDead()
    // {
    //     // 检查Boss的血量是否为零
    //     // 这里需要根据你的游戏逻辑和Boss血量管理的方式来实现
    //     // 假设Boss有一个叫做BossHealth的组件管理血量
    //     BossHealth bossHealth = GetComponent<BossHealth>();
    //     if (bossHealth != null && bossHealth.health <= 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
}
