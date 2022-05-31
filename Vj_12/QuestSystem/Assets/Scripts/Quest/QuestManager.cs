using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public GameObject QuestUIParent;
    public GameObject QuestUI;
    public QuestsCollection questsCollection;

    #region Singleton

    private static QuestManager instance;

    void Awake () {
        instance = this;
    }
    #endregion

    void Start()
    {
        // When starting the scene add all the current quests in progress to the UI
        foreach(var quest in Quests.quests.FindAll(q => q.IsInProgress()))
        {
            ShowQuestInUI(quest);
        }
    }

    // Quick getter for questCollection
    public static QuestsCollection Quests
    {
        get { return instance.questsCollection; }
    }

    // Set the quest as in progress
    public static void AcceptQuest(string name)
    {
        AcceptQuest(Quests.Find(name));
    }

    // Set the quest as in progress
    public static void AcceptQuest(Quest quest)
    {
        if(!quest.IsInitial())
        {
            // Quest in progress or already completed, bail out
            return;
        }

        // Check if required quests are completed before starting this quest
        if(quest.HasPrerequiredQuests())
        {
            // Filter quests by the name and QuestStatus to find
            // all the required quests that are not completed yet
            var reqQuests = Quests.quests.FindAll(
                q => quest.requiredQuests.Contains(q.name) && !q.IsCompleted());

            // Display the first required quest if any in list
            if(reqQuests.Count > 0)
            {
                RequiredQuestNotFinished(reqQuests[0]);
                return;
            }

        }

        // Mark quest as in progress
        quest.SetInProgress();
     
        // Display the quest on the UI
        ShowQuestInUI(quest);
    }


    static void ShowQuestInUI(Quest quest)
    {
        // Instantiate new clone of the quest prefab
        var questGO = Instantiate(instance.QuestUI, instance.QuestUIParent.transform);

        // Set the Quest to the QuestUI component
        var questUI = questGO.GetComponent<QuestUI>();
        questUI.Quest = quest;

    }

   

    static void RequiredQuestNotFinished(Quest quest)
    {
        Debug.Log("Complete required quest: " + quest.name);
    }

   
    // Should be called every time the enemy is killed
    public static void EnemyKilled(EnemyType enemyType)
    {
        Debug.Log("Enemy killed " + enemyType);

        // Find all quests currently in progress where a objective is to kill a enemy of type enemyType
        List<Quest> quests = Quests.quests.FindAll(q => q.IsInProgress() && q.IsKillEnemy(enemyType));
        ProgressQuests(quests);
    }

    // Should be called every time any item is collected
    public static void ItemCollected(ItemType itemType)
    {
        Debug.Log("Item collected " + itemType);

        // Find all quests currently in progress where a objective is to collect a item of type itemType
        List<Quest> quests = Quests.quests.FindAll(q => q.IsInProgress() && q.IsCollectItem(itemType));
        ProgressQuests(quests);
    }

    // Called from QuestLocation script when the player reaches the target position
    public static void ArriveAtLocation(string location)
    {
        Debug.Log("Arrived at location: " + location);

        // Find all quests currently in progress where a objective is to go at a location with the name "location"
        List<Quest> quests = Quests.quests.FindAll(q => q.IsInProgress() && q.IsArrivaAtLocation(location));
        ProgressQuests(quests);
    }

    // Progresses all quests by one step 
    static void ProgressQuests(List<Quest> quests)
    {
        foreach (var q in quests)
        {
            ProgressQuest(q);
        }
    }

    // Progress quest by one step
    static void ProgressQuest(Quest quest)
    {
        // Progress the quest
        quest.DoProgress();

        // Refresh the UI to display new information
        RefreshQuestUI(quest);

        // If the quest is completed award the player with the reward items
        // and add new quests if any
        if (quest.IsCompleted())
        {
            // Award the items
            AwardItems(quest);
            
            // Start the next quests
            StartNextQuests(quest);
        }
    }

    static void StartNextQuests(Quest quest){
        // Start the next quests if any
        if (quest.HasNextQuests())
        {
            foreach (var questName in quest.questAfterCompleted)
                AcceptQuest(questName);
        }
    }
    static void AwardItems(Quest quest)
    {
        // Return if no reward items
        if (!quest.HasRewardItems())
            return;

        // Here the reward items should be added to the player
        foreach (var ri in quest.rewardItems)
        {
            // For this example just print them out
            Debug.Log(string.Format("Rewarded {1} {0}", ri.type, ri.quantity));
        }

    }

    // Refreshes the quest on the UI
    static void RefreshQuestUI(Quest quest)
    {
        // Get all QuestUI components from children
        foreach (var questUI in instance.QuestUIParent.GetComponentsInChildren<QuestUI>())
        {
            // And find the component with the quest with the same name
            if (questUI.Quest == quest)
            {
                // Update UI with the new quest info
                questUI.UpdateUI();
                break;
            }
        }
    }

}
