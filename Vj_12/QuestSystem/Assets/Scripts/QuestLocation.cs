using UnityEngine;


// A class that is attached to a gameobject in the scene
// When the player enters the collider trigger or collides with the collider,
// QuestManager is updated with LocationName, i.e. a currently active quest
// with the locationName indentical with LocationName is completed
public class QuestLocation : MonoBehaviour {

    public string LocationName;

    void OnTriggerEnter(Collider other)
    {
        ArrivedAtLocation();
    }

    void OnCollisionEnter(Collision collision)
    {
        ArrivedAtLocation();
    }

    public void ArrivedAtLocation()
    {
        QuestManager.ArriveAtLocation(LocationName);
    }
}
