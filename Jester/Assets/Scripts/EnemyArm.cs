using RagdollCreatures;
using UnityEngine;
using System.Collections;

public class EnemyArm : MonoBehaviour
{
    [SerializeField] RagdollLimb[] limbs;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float delayBetweenTransitions = 0.5f;

    float muscleForce;
    bool increasing;

    void Start()
    {
        StartCoroutine(TransitionCoroutine());
    }

    IEnumerator TransitionCoroutine()
    {
        while (muscleForce < 10)
        {
            muscleForce += Time.deltaTime * speed;
            UpdateMuscleForce();
            yield return null;
        }

        yield return new WaitForSeconds(delayBetweenTransitions);

        while (muscleForce > 0.1f)
        {
            muscleForce -= Time.deltaTime * speed;
            UpdateMuscleForce();
            yield return null;
        }

        yield return new WaitForSeconds(delayBetweenTransitions);
        StartCoroutine(TransitionCoroutine());

    }

    void UpdateMuscleForce()
    {
        for (int i = 0; i < limbs.Length; i++)
        {
            limbs[i].muscleForce = muscleForce;
        }
    }
}