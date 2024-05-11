using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // 障碍物预制体
    public float obstacleSpeed = 5f; // 障碍物移动速度
    public float obstacleLifetime = 10f; // 障碍物存在时间
    public float obstacleSpawnInterval = 5f; // 障碍物生成间隔

    private float spawnTimer = 0f;

    void Update()
    {
        // 计时器
        spawnTimer += Time.deltaTime;

        // 如果计时器超过了生成间隔，则生成障碍物
        if (spawnTimer >= obstacleSpawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f; // 重置计时器
        }
    }

    void SpawnObstacle()
    {
        // 随机生成障碍物位置
        Vector3 spawnPosition = FindValidSpawnPosition();

        // 实例化障碍物
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // 设定障碍物移动速度
        Rigidbody2D obstacleRigidbody = obstacle.GetComponent<Rigidbody2D>();
        if (obstacleRigidbody != null)
        {
            obstacleRigidbody.velocity = Vector2.left * obstacleSpeed;
        }

        // 设置障碍物销毁时间
        Destroy(obstacle, obstacleLifetime);
    }

    Vector3 FindValidSpawnPosition()
    {
        Vector3 spawnPosition;
        bool positionIsValid = false;

        // 重复生成障碍物直到找到一个有效的位置
        do
        {
            float randomX = Random.Range(-8f, 8f);
            float randomY = Random.Range(-8f, 8f);
            spawnPosition = new Vector3(randomX, randomY, 0f);

            // 检查障碍物是否与其他障碍物重叠
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f);
            if (colliders.Length == 0)
            {
                positionIsValid = true;
            }
        } while (!positionIsValid);

        return spawnPosition;
    }
}

