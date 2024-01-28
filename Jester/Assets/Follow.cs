using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform handL;
    [SerializeField] Transform handR;
    [SerializeField] float followSpeed = 5f;

    void Update()
    {
        Transform targetHand = GetTargetHand();

        if (targetHand != null)
        {
            transform.parent = targetHand;

            transform.position = targetHand.position;

            RotateTowardsMouse();
        }
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;

        transform.up = direction.normalized;
    }

    Transform GetTargetHand()
    {
        bool isMouseOnLeft = Input.mousePosition.x < Screen.width / 2;

        if (isMouseOnLeft)
        {
            return handL;
        }
        else
        {
            return handR;
        }
    }
}
