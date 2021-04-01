using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{

    public void QuestCompleted()
    {
        var questText = GetComponentInChildren<Text>().text;
        Debug.Log(questText);
        // Self destruct
        Destroy(gameObject);
    }
}
