using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int nextScene;

    void Awake()
    {
        // When starting the game return to the last saved scene
        if(SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("Level", 0))
        {
            nextScene = PlayerPrefs.GetInt("Level", 0);
            NextLevel();
        }
            
    }

    void Start()
    {

        // Get current level and increase by one
        nextScene = (PlayerPrefs.GetInt("Level", 0) + 1) % SceneManager.sceneCountInBuildSettings;

        var text = GetComponentInChildren<Text>();
        text.text = "Go Level " + nextScene.ToString();
    }

    public void NextLevel()
    {

        // Load the scene with the given index
        SceneManager.LoadScene(nextScene);

        // Set the next level as the current
        PlayerPrefs.SetInt("Level", nextScene);
        PlayerPrefs.Save();

    }
}
