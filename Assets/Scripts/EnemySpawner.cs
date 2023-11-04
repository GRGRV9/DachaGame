using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject enemyPrefab;
    private Quaternion spawnPosition;

    public void SpawnEnemy()
    {
        spawnPosition = Quaternion.Euler(new Vector3(0, 0, Random.Range(-40, 40)));
        Debug.Log(spawnPosition); 
        Instantiate(enemyPrefab, new Vector3(0, 0, 0), spawnPosition);
    }
    

}
