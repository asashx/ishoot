using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 敌人预制体数组，可以添加多种敌人
    public Transform[] spawnPoints; // 生成点数组
    public float timeBetweenWaves = 5f; // 波次间隔时间
    public int enemiesPerWave = 5; // 每波生成的敌人数量

    protected virtual void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    protected virtual IEnumerator SpawnEnemyWaves()
    {
        yield return new WaitForSeconds(2f); // 延迟一段时间再开始生成

        int waveCount = 0;

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount++;

            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }

            Debug.Log("Wave " + waveCount + " spawned.");

            // // 检查敌人是否都被消灭
            // while (GameObject.FindGameObjectWithTag("Enemy") != null)
            // {
            //     yield return null;
            // }

            Debug.Log("Wave " + waveCount + " cleared.");
        }
    }
}
