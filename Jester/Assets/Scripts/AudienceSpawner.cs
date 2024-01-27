using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public GameObject personPrefab;
    public float noSpawnChance = 0.2f; // 20% chance of not spawning

    public Sprite[] heads;
    public Sprite[] bodies;
    GameObject personInstance = null;

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
                Sprite randomHead = heads[Random.Range(0, heads.Length)];
                Sprite randomBody = bodies[Random.Range(0, bodies.Length)];
                personInstance = Instantiate(personPrefab, child.position, Quaternion.identity);
                personInstance.transform.parent = transform;
                personInstance.GetComponent<SpriteRenderer>().sprite = randomBody;
                personInstance.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = randomHead;
            }
        }
    }
}
