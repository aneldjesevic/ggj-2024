using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    [Header("Right arm parts")]
    [SerializeField] SpriteRenderer lowerRightArm;
    [SerializeField] SpriteRenderer upperRightArm;

    [Header("Left arm parts")]
    [SerializeField] SpriteRenderer lowerLeftArm;
    [SerializeField] SpriteRenderer upperLeftArm;

    [SerializeField] SpriteRenderer[] sprites;

    private void Start()
    {
        FlipChildrenXScale(false);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0.05f)
        {
            FlipChildrenXScale(false);
        }
        else if (horizontalInput < -0.05f)
        {
            FlipChildrenXScale(true);
        }
    }

    void FlipChildrenXScale(bool shouldFlip)
    {
        foreach (SpriteRenderer sr in sprites)
        {
            sr.flipX = shouldFlip;

            if (shouldFlip)
            {
                upperLeftArm.sortingOrder = 1;
                lowerLeftArm.sortingOrder = 1;

                upperRightArm.sortingOrder = 5;
                lowerRightArm.sortingOrder = 5;

            }
            else
            {

                upperLeftArm.sortingOrder = 5;
                lowerLeftArm.sortingOrder = 5;

                upperRightArm.sortingOrder = 1;
                lowerRightArm.sortingOrder = 1;
            }
        }
    }
}
