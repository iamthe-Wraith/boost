using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float loadLevelDelay = 2f;

    [Header("Particles")]
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    Movement mvmt;
    AudioManager audioManager;

    bool isTransitioning = false;

    private void Start()
    {
        mvmt = GetComponent<Movement>();
        audioManager = GetComponent<AudioManager>();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }

        switch (other.gameObject.tag)
        {
            case "Start":
                // do nothing
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }    
    }


    private void StartCrashSequence()
    {
        isTransitioning = true;
        mvmt.enabled = false;
        audioManager.Stop();
        audioManager.PlayCrashExplosion();
        crashParticles.Play();
        Invoke("ReloadLevel", loadLevelDelay);
    }
    
    private void StartSuccessSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        audioManager.Stop();
        audioManager.PlaySuccessfulLanding();
        successParticles.Play();
        Invoke("LoadNextLevel", loadLevelDelay);
    }

    private void LoadNextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevelIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }

        isTransitioning = false;
        SceneManager.LoadScene(nextLevelIndex);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isTransitioning = false;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
