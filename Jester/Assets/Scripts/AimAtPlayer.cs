using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform armToAim;

    public float forceMagnitude = 5f;

    private Rigidbody2D armRigidbody;

    void Start()
    {
        // Find the player using its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }

        // Get the Rigidbody2D component of the arm
        armRigidbody = armToAim.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null || armToAim == null)
            return;

        // Calculate the direction to the player
        Vector2 directionToPlayer = player.position - armToAim.position;

        // Normalize the direction vector to have a magnitude of 1
        directionToPlayer.Normalize();

        // Add force towards the player
        armRigidbody.AddForce(directionToPlayer * forceMagnitude);
    }
}
