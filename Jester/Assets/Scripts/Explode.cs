using RagdollCreatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] GameObject[] bodyParts;

    public void ExplodeObj(bool shouldDestroy)
    {
        foreach (GameObject part in bodyParts)
        {
            Destroy(part.GetComponent<HingeJoint2D>());
            if (part.GetComponent<Grab>())
                Destroy(part.GetComponent<Grab>());
            Destroy(part.GetComponent<RagdollLimb>());
            Destroy(part.GetComponent<Damagable>());

            part.transform.SetParent(null);

            Rigidbody2D rb = part.GetComponent<Rigidbody2D>();

            rb.angularDrag = 3;
            rb.drag = 1;


            part.gameObject.layer = 3;

            Vector2 randomForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            float forceMagnitude = Random.Range(10f, 40f);
            rb.AddForce(randomForce * forceMagnitude);

            Destroy(part, 2.5f);
            if (shouldDestroy)
                Destroy(gameObject);
        }
    }
}
