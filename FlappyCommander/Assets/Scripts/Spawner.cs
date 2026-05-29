using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstacleSpikyPrefab;
    public float spawnRate = 2f;
    public float heightOffset = 2f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnRate);
    }

    void Spawn()
    {
        float y = Random.Range(-heightOffset, heightOffset);
        GameObject prefabToSpawn = Random.value > 0.5f ? obstaclePrefab : obstacleSpikyPrefab;
        Instantiate(prefabToSpawn, new Vector3(10f, y, 0), Quaternion.identity);
    }
}
