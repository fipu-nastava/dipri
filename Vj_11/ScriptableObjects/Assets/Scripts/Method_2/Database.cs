using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

    public static Database Instance { get; private set;}

    public ItemsDatabase db;

    void Awake()
    {
        Instance = this;    
    }

}
