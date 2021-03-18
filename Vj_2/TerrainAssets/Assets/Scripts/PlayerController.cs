using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;


    void FixedUpdate()
    {

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");


        var movement = new Vector3(moveVertical, 0, moveHorizontal*-1);

        transform.position += movement * speed;
    }


}
