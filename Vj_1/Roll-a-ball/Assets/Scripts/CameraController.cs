using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Remember the initial offset between camera and the player
        offset = transform.position - playerTransform.position;   
    }

    // Update once all gameobject are updated (Update() function called upon them)
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;   
    }
}
