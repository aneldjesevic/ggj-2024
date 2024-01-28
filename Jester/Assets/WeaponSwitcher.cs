using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] GameObject poofParticles;

    [SerializeField] float minTime = 20f;
    [SerializeField] float maxTime = 40f;

    AudioSource audiosource;

    [SerializeField] GameObject[] weapons;
    int newChosenWeapon;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        StartCoroutine(ChangeWeapons());
    }

    IEnumerator ChangeWeapons()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        foreach (GameObject weapon in weapons)
        {
            if (weapon.activeSelf)
            {
                Instantiate(poofParticles, weapon.transform.position, Quaternion.identity);
            }
        }

        do
        {
            newChosenWeapon = Random.Range(0, weapons.Length);

        }
        while (weapons[newChosenWeapon].gameObject.activeSelf);

        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        audiosource.Play();
        weapons[newChosenWeapon].SetActive(true);

        StartCoroutine(ChangeWeapons());
    }
}
