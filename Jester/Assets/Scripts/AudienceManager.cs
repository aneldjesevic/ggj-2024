using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{
    [SerializeField] AudioSource crowdAudioSource;
    [SerializeField] AudioSource kingAudioSource;
    [SerializeField] AudioSource headshotAudiosource;

    float currentVolume;

    [SerializeField] float speed = 5;

    [SerializeField] HealthObj healthObj;

    private void Start()
    {
        currentVolume = 0.02f;
        crowdAudioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(int stage)
    {
        if (stage == 0)
        {
            //no hit
            currentVolume = 0.01f;
            crowdAudioSource.volume = currentVolume;
        }
        else if (stage == 1)
        {
            Debug.Log("Normal kill");

            //normal hit
            currentVolume = 0.055f;
            healthObj.GainHealth(1);
            crowdAudioSource.volume = currentVolume;

            kingAudioSource.volume = 0.1f;
            if (!kingAudioSource.isPlaying)
                kingAudioSource.Play();
        }
        else if (stage == 2)
        {
            Debug.Log("HeadShot kill");

            //headshot hit
            currentVolume = 0.08f;
            healthObj.GainHealth(3);
            crowdAudioSource.volume = currentVolume;

            headshotAudiosource.Play();

            kingAudioSource.volume = 0.25f;
            if (!kingAudioSource.isPlaying)
                kingAudioSource.Play();
        }
        else if (stage == 3)
        {
            //double kill
            Debug.Log("Double kill");

            currentVolume = 0.1f;
            healthObj.GainHealth(5);
            if (!kingAudioSource.isPlaying)
                crowdAudioSource.volume = currentVolume;

            kingAudioSource.volume = 0.5f;
            kingAudioSource.Play();
        }
        Invoke("ResetState", 1f);
    }

    private void Update()
    {
        crowdAudioSource.volume = Mathf.Lerp(crowdAudioSource.volume, currentVolume, speed * Time.deltaTime);
    }
    void ResetState()
    {
        currentVolume = 0.02f;
    }
}
