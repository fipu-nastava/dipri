using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Class that display information about the specific quest
public class QuestUI : MonoBehaviour
{

    public Text questName;
    public Text questDescription;

    // Reference to a quest
    private Quest quest;
    public Quest Quest {
        get
        {
            return quest;
        }
        set
        {
            quest = value;
            // Update the UI with the quest info
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        questName.text = Quest.displayName;
        questDescription.text = Quest.description;

        var progress = Quest.GetProgressText();
        if (progress != null)
        {
            questDescription.text += "\n" + progress;
        }

        // Remove the quest when completed
        if (quest.IsCompleted())
        {
            Remove();
        }
    }

    public void Remove()
    {
        // If a quest doesn't have reward items simply fade out before destroying the gameObject
        if (!Quest.HasRewardItems())
            StartCoroutine(FadeCorutine(-0.1f));
        else
            // First show the received reward items and then fade out and destroy the gameObject
            StartCoroutine(ShowRecievedItems());
    }

    IEnumerator ShowRecievedItems()
    {
        yield return new WaitForSeconds(1);

        var tekst = "";

        foreach(var rewardItem in Quest.rewardItems)
        {
            tekst += rewardItem.quantity + " " + rewardItem.type + ", ";
        }

        questDescription.text = "Recieved: " + tekst.Substring(0, tekst.Length - 2);

        yield return new WaitForSeconds(3);

        StartCoroutine(FadeCorutine(-0.1f));
    }

    IEnumerator FadeCorutine(float delta)
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha <= 1 && canvasGroup.alpha > 0)
        {
            canvasGroup.alpha += delta;
            yield return new WaitForSeconds(.1f);
        }
        Destroy(gameObject);

    }
}
