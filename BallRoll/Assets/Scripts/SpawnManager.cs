using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    int enemyCount;
    int powerupCount;
    int waveEvemies = 3;
    // Start is called before the first frame update
    void Start()
    {
        EnemyWaveSpawn(waveEvemies);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private void EnemyWaveSpawn(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }



    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        powerupCount = FindObjectsOfType<PowerUp>().Length;

        if(enemyCount == 0)
        {
            waveEvemies += 2;
            EnemyWaveSpawn(waveEvemies);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    IEnumerator PowerUpExisenz()
    {
        if (powerupCount > 2)
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
        

    }

private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 enemySpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return enemySpawnPos;
    }

}
