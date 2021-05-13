using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemObject : ScriptableObject
{
    public new string name;
    public GameObject gameObject;
    public float health;
    public float strength;


    public string Info()
    {
        return string.Format("{0} - health: {1}, strength: {2}", name, health, strength);
    }
    
}
