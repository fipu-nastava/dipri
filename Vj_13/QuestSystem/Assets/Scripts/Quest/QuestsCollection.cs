using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Quests Collection")]
public class QuestsCollection : ScriptableObject {

    [SerializeField]
    public List<Quest> quests;

    public Quest Find(string name)
    {
        return quests.Find(quest => quest.name == name);
    }
}
