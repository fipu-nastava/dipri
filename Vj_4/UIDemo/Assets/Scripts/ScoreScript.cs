using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int score=0;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + (++score).ToString();
    }
}
