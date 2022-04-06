using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{

    private Light pointLight;
    private AudioSource audioSource;

    private static int Score = 0;

    void Start()
    {
        // Save references to the components
        audioSource = GetComponent<AudioSource>();
        pointLight = GetComponent<Light>();
        // Turn off the light at the begining 
        pointLight.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Turn on the light
        pointLight.enabled = true;

        // Play the sound effect
        audioSource.Play();

        // Increase the score
        IncreaseScore();
    }
    void OnTriggerExit(Collider other)
    {
        pointLight.enabled = false;
    }
    void IncreaseScore()
    {
        Score++;

        // UIController could be eather a sigleton or passed to a GameManager
        // But in this case, to keep it simple we can just search for it
        var ui = FindObjectOfType<UIController>();
        ui.UpdateScore(Score);
    }
}
