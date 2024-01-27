using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    [SerializeField] HealthObj healthObj;
    [SerializeField] float knockbackForce = 500f; // Adjust the force as needed

    float timer;
    float delay = 0.1f;

    [SerializeField] GameObject bloodParticles;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timer <= 0 && healthObj.timer <= 0)
        {
            Weapon weaponComponent = collision.gameObject.GetComponent<Weapon>();
            if (weaponComponent != null && collision.gameObject.transform.parent != null)
            {
                Instantiate(bloodParticles, transform.position, Quaternion.identity);
                TakeDamage(weaponComponent.damage, collision.gameObject);
            }
        }
    }

    void TakeDamage(int damage, GameObject collision)
    {
        timer = delay;
        healthObj.health -= damage;
        healthObj.timer = delay;

        Knockback(collision);
    }

    void Knockback(GameObject collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
