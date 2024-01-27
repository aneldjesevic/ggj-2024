using RagdollCreatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float stoppingDistance = 1f;

    public Rigidbody2D leftRB;
    public Rigidbody2D rightRB;

    private Rigidbody2D currentRB;
    [SerializeField] private Transform player;

    public SpriteRenderer[] spriteRenderers;

    [SerializeField] GameObject upperRightArm;
    [SerializeField] GameObject lowerRightArm;

    void Start()
    {
        currentRB = leftRB;

        StartCoroutine(SwitchRigidbodyRoutine());

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = player.position - currentRB.transform.position;

        direction.Normalize();

        currentRB.velocity = new Vector2(direction.x * movementSpeed, currentRB.velocity.y);

        FlipSprites(direction.x < 0);
    }

    void FlipSprites(bool isLeft)
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.flipX = isLeft;
        }
        /*if (!isLeft)
        {
            upperRightArm.GetComponent<RagdollLimb>().muscleRotation = 25f;
            lowerRightArm.GetComponent<RagdollLimb>().muscleRotation = 25f;
        }
        else
        {
            upperRightArm.GetComponent<RagdollLimb>().muscleRotation = -25f;
            lowerRightArm.GetComponent<RagdollLimb>().muscleRotation = -25f;
        }*/
    }

    IEnumerator SwitchRigidbodyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(.65f);

            if (currentRB == leftRB)
            {
                currentRB = rightRB;
            }
            else
            {
                currentRB = leftRB;
            }
        }
    }
}
