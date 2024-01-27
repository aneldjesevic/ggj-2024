using RagdollCreatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArm : MonoBehaviour
{
    [SerializeField] RagdollLimb[] limbs;
    [SerializeField] float speed = 1.0f;

    void Start()
    {
    }

    void Update()
    {
        for (int i = 0; i < limbs.Length; i++)
        {
            float muscleForce = Mathf.Sin(Time.time * speed) * 5.0f + 5.0f;

            limbs[i].muscleForce = muscleForce;
        }
    }
}
