using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Using deltaTime for smothing rotation
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
