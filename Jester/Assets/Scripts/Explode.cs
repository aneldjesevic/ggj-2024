using RagdollCreatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] GameObject[] bodyParts;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ExplodeObj()
    {
        foreach (GameObject part in bodyParts)
        {
            Destroy(part.GetComponent<HingeJoint2D>());
            Destroy(part.GetComponent<RagdollLimb>());
            Destroy(part.GetComponent<Damagable>());

            part.transform.SetParent(null);

            Rigidbody2D rb = part.GetComponent<Rigidbody2D>();

            rb.angularDrag = 3;
            rb.drag = 1;


            part.gameObject.layer = 3;

            Vector2 randomForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            float forceMagnitude = Random.Range(5f, 20f);
            rb.AddForce(randomForce * forceMagnitude);

            Destroy(part, 2.5f);
            Destroy(gameObject);
        }
    }
}
