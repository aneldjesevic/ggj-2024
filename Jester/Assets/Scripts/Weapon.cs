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
        }
        if (!collision.gameObject.CompareTag("Player"))
        {
            isBeingHeld = rb.isKinematic;
        }
    }


    private void Update()
    {
        isBeingHeld = rb.isKinematic;

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
