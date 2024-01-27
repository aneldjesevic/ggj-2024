using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    [SerializeField] GameObject[] enemyTypes;
    [SerializeField] float multiplier;
    [SerializeField] float timeBetweenWaves;

    float enemiesToSpawn = 1;

    [SerializeField] Transform spawnL;
    [SerializeField] Transform spawnR;

    bool isInWave;

    [SerializeField] int currentWave;

    [SerializeField] GameObject[] enemies;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public IEnumerator StartWave()
    {
        isInWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);

        float amountOfEnemies = enemiesToSpawn *= multiplier;

        for (int i = 0; i < (int)amountOfEnemies; i++)
        {
            int enemyChosen = Random.Range(0, enemyTypes.Length);
            Debug.Log(enemyChosen);
            int spawnPoint = Random.Range(0, 2);

            if (spawnPoint == 0)
            {
                Instantiate(enemyTypes[enemyChosen], spawnL.position, Quaternion.identity);
            }
            if (spawnPoint == 1)
            {
                Instantiate(enemyTypes[enemyChosen], spawnR.position, Quaternion.identity);
            }
        }
        currentWave++;
        isInWave = false;
    }

    private void Update()
    {
        if (enemies.Length != GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        if (enemies.Length == 0 && !isInWave)
        {
            Debug.Log("Starting Wave" + currentWave);

            StartCoroutine(StartWave());
        }
    }
}
