using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Start the object moving
        rb2d.linearVelocity = new Vector2(GameManager.Instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameOver)
        {
            rb2d.linearVelocity = Vector2.zero;
        }
        
    }
}
