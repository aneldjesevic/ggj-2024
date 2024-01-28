using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWeapon : MonoBehaviour
{
    GameObject weapon1;
    GameObject weapon2;

    [SerializeField] GameObject[] weapons;

    [SerializeField] Transform handL;
    [SerializeField] Transform handR;
    void Start()
    {
        int weapon = Random.Range(0, weapons.Length);

        weapon1 = Instantiate(weapons[weapon], handL.position, Quaternion.identity, handL);
        weapon2 = Instantiate(weapons[weapon], handR.position, Quaternion.identity, handR);

        float randomScale = Random.Range(0.8f, 1.3f);

        weapon1.transform.localScale = Vector3.one * randomScale;
        weapon2.transform.localScale = Vector3.one * randomScale;

    }
}
