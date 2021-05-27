using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A class that is attached to a gameobject in the scene
// When the player enters the collider trigger or collides with the collider,
// QuestManager is updated with ItemType, i.e. quantity of currently active quests
// is increased by one for all of the quests where itemType == Quest.itemType
public class QuestItem : MonoBehaviour
{
    public ItemType itemType;

    void OnTriggerEnter(Collider other)
    {
        ItemPicked();
    }

    void OnCollisionEnter(Collision collision)
    {
        ItemPicked();
    }

    public void ItemPicked()
    {
        QuestManager.ItemCollected(itemType);
        Destroy(gameObject);
    }
}
