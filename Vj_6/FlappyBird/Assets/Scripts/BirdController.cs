using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public float upForce = 5;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the bird is not dead and any key is pressed
        if (!GameManager.Instance.gameOver && Input.anyKeyDown)
        {
            // Since the bird is always  falling/rising it always has some speed
            // so nullify the speed before adding force
            rb2d.linearVelocity = Vector2.zero;

            rb2d.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);

            // Trigger flap animation
            anim.SetTrigger("Flap");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Only die when in collision with objects other than scene limits
        if (other.gameObject.CompareTag("Scenery"))
            return;

        GameManager.Instance.BirdDied();
        // Trigger die animation
        anim.SetTrigger("Die");

    }
}
