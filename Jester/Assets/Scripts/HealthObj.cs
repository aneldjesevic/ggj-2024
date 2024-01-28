using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthObj : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField] float maxHealth;
    public float health;

    public float timer;

    bool hasExploded;

    [SerializeField] GameObject deathParticles;
    [SerializeField] Transform bodyObj;

    public bool isPlayer = false;

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
                for (int i = 0; i < transform.GetChild(0).childCount; i++)
                {
                    if (transform.GetChild(0).GetChild(i).name.ToLower().Contains("lower") && transform.GetChild(0).GetChild(i).name.ToLower().Contains("arm"))
                    {
                        Destroy(transform.GetChild(0).GetChild(i).GetChild(0).gameObject);
                    }
                }



                if (!isPlayer)
                {
                    Destroy(slider.gameObject);
                    GetComponent<Explode>().ExplodeObj(true);
                    Destroy(gameObject, 2.5f);
                }
                else
                {
                    GetComponent<Explode>().ExplodeObj(false);
                    for (int i = 0; i < transform.GetChild(0).childCount; i++)
                    {
                        transform.GetChild(0).GetChild(i).gameObject.layer = LayerMask.NameToLayer("Untouchable");
                    }
                    Invoke("Restart", 2f);
                }
            }
        }

        if (isPlayer)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                health -= Time.deltaTime * 0.3f;
            }
        }
    }
    public void GainHealth(int gainedHealth)
    {
        if (health + gainedHealth <= maxHealth)
            health += gainedHealth;
        else
            health = maxHealth;
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
