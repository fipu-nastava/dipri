using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text countText;
    public GameObject winText;


    void Start()
    {
        // Hide win text at the begining
        winText.SetActive(false);    
    }

    public void UpdateCount(int count)
    {
        countText.text = string.Format("Count: {0}", count);
    }

    public void DisplayWinText()
    {
        winText.SetActive(true);
    }


}
