using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class Damagable : MonoBehaviour
{
    [SerializeField] HealthObj healthObj;
    [SerializeField] float knockbackForce = 500f;

    float timer;
    float delay = 0.1f;

    [SerializeField] GameObject bloodParticles;

    MMFeedbacks feel;

    private void Start()
    {
        feel = GetComponentInParent<MMFeedbacks>();
    }

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

                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(ResetColor(GetComponent<SpriteRenderer>()));
            }
        }
    }

    IEnumerator ResetColor(SpriteRenderer sr)
    {
        yield return new WaitForSeconds(0.6f);

        sr.color = Color.white;
    }

    void TakeDamage(int damage, GameObject collision)
    {
        feel.PlayFeedbacks();
        FindObjectOfType<CameraShake>().ShakeCamera();
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