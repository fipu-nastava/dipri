using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DBPickUpItem
{
    
    public ItemType itemType;
    public GameObject gameObject;
    public float health;
    public float strength;
    public bool pickedUp;


    public string Info()
    {
        return string.Format("{0} - health: {1}, strength: {2}", itemType, health, strength);
    }

}

[CreateAssetMenu(menuName = "Inventory/Items Database")]
public class ItemsDatabase : ScriptableObject
{

    public List<DBPickUpItem> pickUpItems;


    public DBPickUpItem FindByType(ItemType itemType)
    {
        return pickUpItems.Find(x => x.itemType == itemType);
    }

}
