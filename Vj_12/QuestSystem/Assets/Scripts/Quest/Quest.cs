using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest {

    // Possible states in which the quest can be
    public enum QuestState
    {
        Initial,
        InProgress,
        Completed
    }

    // Different objectives of quests
    public enum QuestType
    {
        KillEnemy,
        GoToLocation,
        CollectItems
    }

    // Reward item and quantity
    [Serializable]
    public class Item
    {
        public ItemType type;
        public int quantity;
    }

    [Tooltip("Name of this quest. Can be used in other quests in Required Quests field")]
    public string name;

    [Tooltip("Current quest state")]
    public QuestState questState;

    [Tooltip("Name of the quest to be displayed to the user")]
    public string displayName;

    [Tooltip("Longer description to better describe the quest to the user")]
    public string description;

    [Header("Choose objective type")]

    [Tooltip("Objective type to complete in order to complete the quest")]
    public QuestType questType;


    [ConditionalField("questType", QuestType.KillEnemy)]
    [Tooltip("Type of enemy to kill as an objective")]
    public EnemyType enemyType;

    [ConditionalField("questType", QuestType.GoToLocation)]
    [Tooltip("Name of the location where the player has to go. Add QuestLocation script to a gameobject and give it a the same name to make that game object as an objective")]
    public string locationName;

    [ConditionalField("questType", QuestType.CollectItems)]
    [Tooltip("Type of item to collect")]
    public ItemType itemType;


    [Tooltip("Number of steps required to complete the quest, i.e. number of items to collect, enemies to collect (for location set to 1)")]
    public int requiredAmount;
    [Tooltip("Current number of steps")]
    public int currentAmount;

    [Header("Optional")]

    [Tooltip("A list of quest names required to be completed before starting this quest")]
    public List<string> requiredQuests;

    [Tooltip("A list of quest names to start after completing this quest")]
    public List<string> questAfterCompleted;

    [Tooltip("A list of reward items to reward the player when completing this quest")]
    public List<Item> rewardItems;


    // Mark quest as in progress
    public void SetInProgress()
    {
        questState = QuestState.InProgress;
    }

    // Helper method to check if quest is initial
    public bool IsInitial()
    {
        return questState == QuestState.Initial;
    }

    // Helper method to check if quest in progress
    public bool IsInProgress()
    {
        return questState == QuestState.InProgress;
    }

    // Helper method to check if quest is completed
    public bool IsCompleted()
    {
        return questState == QuestState.Completed;
    }

    // Helper method to check if quest objective is to kill a enemy of type enType
    public bool IsKillEnemy(EnemyType enType)
    {
        return questType == QuestType.KillEnemy && enemyType == enType;
    }

    // Helper method to check if quest objective is to collect a item of type it
    public bool IsCollectItem(ItemType it)
    {
        return questType == QuestType.CollectItems && itemType == it;
    }

    // Helper method to check if quest objective is to go to location with the name location
    public bool IsArrivaAtLocation(string location)
    {
        return questType == QuestType.GoToLocation && location == locationName;
    }

    // Helper method to check if quest has required quest to be completed before starting this quest
    public bool HasPrerequiredQuests()
    {
        return requiredQuests != null && requiredQuests.Count > 0;
    }

    // Helper method to check if quest has reward items
    public bool HasRewardItems()
    {
        return rewardItems != null && rewardItems.Count > 0;
    }

    // Helper method to check if quest has reward items
    public bool HasNextQuests()
    {
        return questAfterCompleted != null && questAfterCompleted.Count > 0;
    }
    

    // Method that returns current progress of the quest to be displayed to the user
    public string GetProgressText()
    {
        var msg = string.Format("{0}/{1} ", currentAmount, requiredAmount);

        
        if (questType == QuestType.CollectItems)
        {
            msg += "items collected";
        }
        else if (questType == QuestType.KillEnemy)
        {
            msg += "enemy's killed";
        }
        else if (questType == QuestType.GoToLocation)
        {
            msg = null;
        }

        return msg;
    }

    // Progress one step of the quest
    public void DoProgress()
    {
        currentAmount++;
        // If all the steps are completed (items collected, enemies killed, location arrived)
        // change the questState to Completed
        if(currentAmount >= requiredAmount)
        {
            questState = QuestState.Completed;

        }
    }
}
