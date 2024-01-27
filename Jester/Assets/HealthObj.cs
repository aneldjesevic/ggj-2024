using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthObj : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField] float maxHealth;
    public float health;

    public float timer;

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

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
