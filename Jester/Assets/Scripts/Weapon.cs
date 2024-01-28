using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Weapon : MonoBehaviour
{
    public int damage;

    MMFeedbacks feel;

    public bool isBeingHeld;
    public bool isPlayerWeapon;

    public Rigidbody2D rb;

    private void Start()
    {
        feel = GetComponent<MMFeedbacks>();
        rb = GetComponent<Rigidbody2D>();

        isBeingHeld = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() && collision.gameObject.transform.parent != null)
        {
            feel.PlayFeedbacks();

            //Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            collision.gameObject.transform.parent.GetComponentInParent<Rigidbody2D>().AddForce(transform.right * 200, ForceMode2D.Impulse);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(-transform.right * 60, ForceMode2D.Impulse);
        }
    }


    private void Update()
    {
        isBeingHeld = transform.parent;

        if (isBeingHeld)
        {
            if (isPlayerWeapon)
                gameObject.layer = LayerMask.NameToLayer("Weapon");
        }
        else
        {
            if (isPlayerWeapon)
                gameObject.layer = LayerMask.NameToLayer("Player");
        }


    }
}
