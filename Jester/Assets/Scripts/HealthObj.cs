using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthObj : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField] float maxHealth;
    public float health;

    public float timer;

    bool hasExploded;

    [SerializeField] GameObject deathParticles;
    [SerializeField] Transform bodyObj;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
    }

    void Update()
    {
        slider.value = health;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (health <= 0 && !hasExploded)
        {
            hasExploded = true;

            Instantiate(deathParticles, bodyObj.position, Quaternion.identity, bodyObj);

            if (GetComponent<Explode>() != null)
            {
                Destroy(slider.gameObject);
                GetComponent<Explode>().ExplodeObj();

                Destroy(gameObject, 2.5f);
            }
        }
    }
}
