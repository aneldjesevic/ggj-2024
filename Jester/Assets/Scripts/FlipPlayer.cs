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

    GameObject currentWeapon;

    private void Start()
    {
        FlipChildrenXScale(false);
    }

    void FixedUpdate()
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

        SetCurrentWeapon();

        if (currentWeapon)
        {
            Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
            Rigidbody2D weaponRb = currentWeapon.GetComponent<Rigidbody2D>();

            if (playerRb && weaponRb)
            {
                Vector2 offset = playerRb.position - weaponRb.position;

                weaponRb.AddForce(offset * 3);
            }
        }
    }




    void SetCurrentWeapon()
    {
        Weapon[] weapons = FindObjectsOfType<Weapon>();

        foreach (Weapon weaponObject in weapons)
        {
            if (weaponObject.isBeingHeld && weaponObject && weaponObject.isPlayerWeapon)
            {
                currentWeapon = weaponObject.gameObject;
            }
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
        if (currentWeapon && currentWeapon.GetComponent<Rigidbody2D>().isKinematic)
        {
            currentWeapon.transform.SetParent(to.GetChild(0));
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localRotation = Quaternion.identity;
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
