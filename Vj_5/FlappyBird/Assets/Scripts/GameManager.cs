using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public bool gameOver = false;

    public float scrollSpeed = -3f;

    public Text scoreText;
    private int score = 0;

    #region Singleton

    public static GameManager Instance { get; private set; } 

    void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(gameObject);

     }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // We need to reset this variable since the GameManager is static
            // and is not reinitialized
            gameOver = false;
        }

    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }



    public void BirdScored()
    {
        if (gameOver)
            return;

        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
