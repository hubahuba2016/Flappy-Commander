using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 3f;
    public float heightRange = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnRate);
    }

    void SpawnEnemy()
    {
        float y = Random.Range(-heightRange, heightRange);
        Instantiate(enemyPrefab, new Vector3(10f, y, 0), Quaternion.identity);
    }
}
