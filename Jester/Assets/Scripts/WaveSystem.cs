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

    [SerializeField] Animator animatorL;
    [SerializeField] Animator animatorR;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public IEnumerator StartWave()
    {
        isInWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);

        float amountOfEnemies = enemiesToSpawn *= multiplier;
        List<GameObject> spawnedEnemies = new List<GameObject>();

        for (int i = 0; i < (int)amountOfEnemies; i++)
        {
            yield return new WaitForSeconds(0.2f);
            int enemyChosen = Random.Range(0, enemyTypes.Length);
            Debug.Log(enemyChosen);
            int spawnPoint = Random.Range(0, 2);

            GameObject newEnemy;
            if (spawnPoint == 0)
            {
                StartOpenAnimR();
                yield return new WaitForSeconds(0.3f);
                newEnemy = Instantiate(enemyTypes[enemyChosen], spawnL.position, Quaternion.identity);
            }
            else
            {
                StartOpenAnimL();
                yield return new WaitForSeconds(0.3f);
                newEnemy = Instantiate(enemyTypes[enemyChosen], spawnR.position, Quaternion.identity);
            }

            spawnedEnemies.Add(newEnemy);
        }

        yield return new WaitUntil(() => AllEnemiesSpawned(spawnedEnemies));

        currentWave++;
        isInWave = false;

        Invoke("StopOpenAnim", 2f);
    }

    bool AllEnemiesSpawned(List<GameObject> spawnedEnemies)
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy == null)
            {
                return false;
            }
        }
        return true;
    }

    void StartOpenAnimL()
    {
        animatorL.SetBool("open", true);
    }
    void StartOpenAnimR()
    {
        animatorR.SetBool("open", true);
    }

    void StopOpenAnim()
    {
        animatorL.SetBool("open", false);
        animatorR.SetBool("open", false);
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
