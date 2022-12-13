using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip mainEngineThrust;
    [SerializeField] AudioClip successfulLanding;
    [SerializeField] AudioClip crashExplosion;

    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();   
    }

    public void PlayCrashExplosion()
    {
        if (audioSource != null && crashExplosion != null)
        {
            audioSource.PlayOneShot(crashExplosion);
        }
    }

    public void PlayMainEngineThrust()
    {
        if (audioSource != null && mainEngineThrust != null)
        {
            audioSource.PlayOneShot(mainEngineThrust);
        }
    }

    public void PlaySuccessfulLanding()
    {
        if (audioSource != null && successfulLanding != null)
        {
            audioSource.PlayOneShot(successfulLanding);
        }
    }
    
    
    public void Stop()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
