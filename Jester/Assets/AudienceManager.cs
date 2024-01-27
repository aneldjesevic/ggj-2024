using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    float currentVolume;

    [SerializeField] float speed = 5;

    private void Start()
    {
        currentVolume = 0.02f;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(int stage)
    {
        if (stage == 0)
        {
            //no hit
            currentVolume = 0.02f;
            audioSource.volume = currentVolume;
        }
        else if (stage == 1)
        {
            //normal hit
            currentVolume = 0.075f;
            audioSource.volume = currentVolume;
        }
        else if (stage == 2)
        {
            //headshot hit
            currentVolume = 0.1f;
            audioSource.volume = currentVolume;
        }
        else if (stage == 3)
        {
            //long hit
            currentVolume = 0.135f;
            audioSource.volume = currentVolume;
        }
        Invoke("ResetState", 1f);
    }

    private void Update()
    {
        audioSource.volume = Mathf.Lerp(audioSource.volume, currentVolume, speed * Time.deltaTime);
    }
    void ResetState()
    {
        currentVolume = 0.02f;
    }
}
