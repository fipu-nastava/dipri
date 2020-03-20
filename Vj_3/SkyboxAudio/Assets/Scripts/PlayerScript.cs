using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // For testing purposes we can use the name to determine
        // the collided object
        // You should usually use tags or components in this case
        if(collision.gameObject.name == "Car")
            AudioManager.Instance.Play(SoundType.Hit);    
    }
    
}
