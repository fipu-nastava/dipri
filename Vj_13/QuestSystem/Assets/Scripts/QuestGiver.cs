using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Temporary class that gives out quests
// In real live this should be connected with some dialogs or similar
public class QuestGiver : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        // Only for testing purposes
        // When the player collides with this object the next quest is issued
        var newQuest = QuestManager.Quests.quests.Find(q => q.IsInitial());
        if(newQuest != null)
            QuestManager.AcceptQuest(newQuest);
    }
}
