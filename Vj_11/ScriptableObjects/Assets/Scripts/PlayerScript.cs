using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public PlayerStats stats;

    // Method 1
    public void PickedUp(ItemObject item)
    {
        stats.health += item.health;
        stats.strength += item.strength;
    }

    // Method 2
    public void PickedUp(DBPickUpItem item)
    {
        stats.health += item.health;
        stats.strength += item.strength;
    }
}
