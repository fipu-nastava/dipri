using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepatingBackground : MonoBehaviour
{

    private float groundHLenghth;  // A float to store the x-axis length of the collider2D attached to the Ground GameObject
    // Start is called before the first frame update
    void Start()
    {
        var groundCollider = GetComponent<BoxCollider2D>();
        //Store the size of the collider along the x axis (its length in units).
        groundHLenghth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the difference along the x axis between the main Camera and
        // the position of the object this is attached to is greater than groundHLenghth
        if (transform.position.x < -groundHLenghth)

            // If true, this means this object is no longer visible and we can safely move it forward to be re-used
            RepositionBg();
    }

    // Moves the object this script is attached to right in order to create our looping background effect
    private void RepositionBg()
    {

        //This is how far to the right we will move our background object, in this case, twice its length
        // This will position it directly to the right of the currently visible background object
        var groundOffset = new Vector2(groundHLenghth * 2f, 0);

        // Move this object from it's position offscreen, behind the player,
        // to the new position off-camera in front of the player
        transform.position = (Vector2) transform.position + groundOffset;

    }
}
