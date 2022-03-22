using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Car"))
            AudioManager.Instance.Play(SoundType.Hit);    
    }
    
}
