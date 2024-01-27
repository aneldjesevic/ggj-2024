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
        float mousePositionX = Input.mousePosition.x / Screen.width;

        if (mousePositionX > 0.5f)
        {
            FlipChildrenXScale(false); 
        }
        else
        {
            FlipChildrenXScale(true); 
        }
    }


    void FlipChildrenXScale(bool shouldFlip)
    {
        foreach (SpriteRenderer sr in sprites)
        {
            sr.flipX = shouldFlip;
        }

        if (shouldFlip)
        {
            TransferChild(lowerRightArm.transform, lowerLeftArm.transform);
            SetSortingOrder(1, 5);
        }
        else
        {
            TransferChild(lowerLeftArm.transform, lowerRightArm.transform);
            SetSortingOrder(5, 1);
        }
    }

    void TransferChild(Transform from, Transform to)
    {
        if (from.childCount > 0)
        {
            Transform child = from.GetChild(0);
            child.SetParent(to);
            child.localPosition = Vector3.zero; 
        }
    }

    void SetSortingOrder(int leftOrder, int rightOrder)
    {
        upperLeftArm.sortingOrder = leftOrder;
        lowerLeftArm.sortingOrder = leftOrder;

        upperRightArm.sortingOrder = rightOrder;
        lowerRightArm.sortingOrder = rightOrder;
    }
}
