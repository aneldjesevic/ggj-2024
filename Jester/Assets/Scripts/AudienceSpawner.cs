using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public GameObject[] personPrefabs;
    public float noSpawnChance = 0.2f; // 20% chance of not spawning

    void Start()
    {
        SpawnAudience();
    }

    void SpawnAudience()
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        foreach (Transform child in children)
        {
            float randomChance = Random.value;

            if (randomChance > noSpawnChance)
            {
                GameObject randomPrefab = personPrefabs[Random.Range(0, personPrefabs.Length)];

                if (randomPrefab != null)
                {
                    GameObject personInstance = Instantiate(randomPrefab, child.position, Quaternion.identity);
                    personInstance.transform.parent = transform;
                }
            }
        }
    }
}
