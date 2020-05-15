using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Method 1
    public ItemObject item;
    
    void Start()
    {
        // Create a clone of the prefab and add it as a child to this gameObject
        Instantiate(item.gameObject, gameObject.transform);
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked up: " + item.Info());
            Destroy(gameObject);

            // Ideally this is something that a static GameManager script should
            // handle, since that script would contain the reference to the player
            // but for this example this is just fine
            other.gameObject.GetComponent<PlayerScript>().PickedUp(item);
        } 
    }



}
