using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

    private static Database instance;

    public static Database Instance { get => instance; }

    public ItemsDatabase db;

    void Awake()
    {
        instance = this;    
    }

}
