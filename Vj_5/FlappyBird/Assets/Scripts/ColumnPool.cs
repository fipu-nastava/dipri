using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;                                    //The column game object.
    public int columnPoolSize = 5;                                    //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.
    public float columnMin = -1f;                                    //Minimum y value of the column position.
    public float columnMax = 3.5f;                                    //Maximum y value of the column position.

    private List<GameObject> columns;                                    //Collection of pooled columns.
    private int currentColumn = 0;                                    //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);        //A holding position for our unused columns offscreen.
    private float spawnXPosition = 10f;

    

    private GameObject CurrentColumn
    {
        get
        {
            return columns[currentColumn];
        }
    }

    void Start()
    {
        
        // Initialize the columns collection
        columns = new List<GameObject>();
        // Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++)
        {
            // ...and create the individual columns
            var column = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            columns.Add(column);
        }

        StartCoroutine(StartSpawningColumns());
    }

    IEnumerator StartSpawningColumns()
    {
        while (!GameManager.Instance.gameOver)
        {
            var spawnYPosition = Random.Range(columnMin, columnMax);

            CurrentColumn.transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentColumn++;
            currentColumn %= columnPoolSize;

            yield return new WaitForSeconds(spawnRate);
        }
    }


}
