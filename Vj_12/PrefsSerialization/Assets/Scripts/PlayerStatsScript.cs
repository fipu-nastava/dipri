using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Try to load stats
        var ps = Load();
        // If there are none, fill them with random values
        if(ps == null)
        {
            ps = new PlayerStats
            {
                name = "Test",
                health = 64,
                position = new SVector3(12, 3, 4)
            };
            Save(ps);
        }

        // Show stats on screen
        DisplayStats(ps);
        
    }

    void DisplayStats(PlayerStats ps)
    {
        var text = GetComponent<Text>();
        text.text = string.Format("Name: {0}\nHealth: {1}\nPosition: {2}", ps.name, ps.health, (Vector3)ps.position);
    }

    static void Save(PlayerStats ps)
    {
        // save
        // Create formater which will be used to write values to file
        BinaryFormatter bf = new BinaryFormatter();
        // Open file stream towards file
        FileStream file = File.Create(Application.persistentDataPath + "/progress_save.dat");
        // Serialize class to the file
        bf.Serialize(file, ps);
        Debug.Log("Saving (binary) progress to " + Application.persistentDataPath);
        // Close file stream
        file.Close();
    }

    static PlayerStats Load()
    {
        var path = Application.persistentDataPath + "/progress_save.dat";
        // open
        if (!File.Exists(path))
            return null;

        // Indentical formatter must be used to read values as the on which wrote the values
        BinaryFormatter bf = new BinaryFormatter();

        // Open file stream towards file
        FileStream file = File.OpenRead(path);

        // Desearialize from file and cast to PlayerStats
        PlayerStats p = (PlayerStats)bf.Deserialize(file);
        // Close file stream
        file.Close();

        Debug.Log("Loaded (binary) progress from " + path);
        Debug.Log(p.name + " " + p.health + " " + (Vector3)p.position);
        return p;
    }

}
