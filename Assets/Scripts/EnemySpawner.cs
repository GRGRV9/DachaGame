using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    private Quaternion spawnPosition;

    public void SpawnEnemy1()
    {
        spawnPosition = Quaternion.Euler(new Vector3(0, 0, Random.Range(-40, 40)));
        Instantiate(enemy1Prefab, new Vector3(0, 0, 0), spawnPosition);
    }
    public void SpawnEnemy2()
    {
        spawnPosition = Quaternion.Euler(new Vector3(0, 0, Random.Range(-40, 40)));
        Instantiate(enemy2Prefab, new Vector3(0, 0, 0), spawnPosition);
    }
    public void SpawnEnemy3()
    {
        spawnPosition = Quaternion.Euler(new Vector3(0, 0, Random.Range(-40, 40)));
        Instantiate(enemy3Prefab, new Vector3(0, 0, 0), spawnPosition);
    }
}
