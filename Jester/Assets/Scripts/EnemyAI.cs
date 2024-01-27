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

    [SerializeField] GameObject handL;
    [SerializeField] GameObject handR;

    void Start()
    {
        currentRB = leftRB;

        StartCoroutine(SwitchRigidbodyRoutine());

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player)
        {
            Vector2 direction = player.position - currentRB.transform.position;

            direction.Normalize();

            currentRB.velocity = new Vector2(direction.x * movementSpeed, currentRB.velocity.y);

            FlipSprites(direction.x < 0);
        }
    }

    void FlipSprites(bool isLeft)
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.flipX = isLeft;
        }
         if (!isLeft)
        {
             handL.SetActive(false);
             handR.SetActive(true);
        }
        else
        {
            handR.SetActive(false);
            handL.SetActive(true);
        } 
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
