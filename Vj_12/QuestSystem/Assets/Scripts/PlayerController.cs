using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.position += movement;
    }

    void Update()
    {
        // For testing purposes pressing K kills goblin enemy
        if (Input.GetKeyDown(KeyCode.G))
        {
            QuestManager.EnemyKilled(EnemyType.Goblin);
        }
        // For testing purposes pressing M kills monster enemy
        if (Input.GetKeyDown(KeyCode.M))
        {
            QuestManager.EnemyKilled(EnemyType.Monster);
        }
    }
}
