using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 2f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnRate);
    }

    void Spawn()
    {
        float y = Random.Range(-heightOffset, heightOffset);
        Instantiate(obstaclePrefab, new Vector3(10f, y, 0), Quaternion.identity);
    }
}

