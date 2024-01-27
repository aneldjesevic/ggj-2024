using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Weapon : MonoBehaviour
{
    public int damage;

    MMFeedbacks feel;

    private void Start()
    {
        feel = GetComponent<MMFeedbacks>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.GetComponent<Weapon>() && collision.gameObject.transform.parent != null)
        {
            feel.PlayFeedbacks();
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() && collision.gameObject.transform.parent != null)
        {
            feel.PlayFeedbacks();
        }
    }
}
