using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemType : MonoBehaviour
{

    // Method 2
    public ItemType itemType;

    void Start()
    {
        
        var item = Database.Instance.db.FindByType(itemType);

        // Don't recreate if already picked
        if (item.pickedUp)
        {
            Destroy(gameObject);
            return;
        }
            

        // Create a clone of the prefab and add it as a child to this gameObject
        Instantiate(item.gameObject, gameObject.transform);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            var item = Database.Instance.db.FindByType(itemType);

            Debug.Log("Picked up: " + item.Info());
            Destroy(gameObject);

            // Ideally this is something that a static GameManager script should
            // handle, since that script would contain the reference to the player
            // but for this example this is just fine
            other.gameObject.GetComponent<PlayerScript>().PickedUp(item);
            item.pickedUp = true;
        }
    }
}
