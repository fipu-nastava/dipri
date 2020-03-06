using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    private int count;

    public UIController uiController;

    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateCountText();
    }


    void FixedUpdate()
    {

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");


        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Option 1 - controling player position
        //transform.position += movement * speed;

        // Option 2 (better) - controling forces impacting the player
        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        var otherGO = other.gameObject;

        if(otherGO.CompareTag("Pick Up"))
        {
            count++;
            UpdateCountText();
            otherGO.SetActive(false);
        }
        
    }


    void UpdateCountText()
    {
        // Let the UIController worry on updating the text
        // we are just sending him th new value
        uiController.UpdateCount(count);
        if(count>=12)
        {
            // Let the UIController display win text if all items are collected
            uiController.DisplayWinText();
        }
    }
}
