using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    private Quaternion spawnPosition;

    private void Start()
    {
        StartCoroutine(StartGame());
    }


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

    IEnumerator StartGame()
    {
        Debug.Log("Start Wave 1");
        yield return new WaitForSeconds(5f);
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(15f);
        Debug.Log("Start Wave 2");
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(15f);
        Debug.Log("Start Wave 3");
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy3();
        yield return new WaitForSeconds(15f);
        Debug.Log("Start Wave 4");
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(15f);
        Debug.Log("Start Wave 5");
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(1f);
        SpawnEnemy3();
        yield return new WaitForSeconds(15f);
        Debug.Log("Start Wave 6");
        SpawnEnemy1();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(1f);
        SpawnEnemy2();
        yield return new WaitForSeconds(1f);
        SpawnEnemy3();
        yield return new WaitForSeconds(1f);
        SpawnEnemy3();
    }
}
