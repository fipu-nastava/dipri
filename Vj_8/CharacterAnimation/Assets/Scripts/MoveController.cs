using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MoveController requires the GameObject to have a Animator component
[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{
    public string SprintButton = "Sprint"; // Name set under Edit->Project Settings-> Input Managers
    public string JumpButton = "Jump";

    static int forwardFloat = Animator.StringToHash("Forward");
	static int jumpTrigger = Animator.StringToHash("Jump");

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Are we going forward?
        var v = Input.GetAxis("Vertical");
        // If sprinting double the speed
        var sprinting = Input.GetButton(SprintButton);
        if (sprinting)
            v *= 2;
        // Apply the value to the animator
        anim.SetFloat(forwardFloat, v, 0.1f, Time.deltaTime);

        // Transition to jump animation if we jumped
        var jump = Input.GetButton(JumpButton);
        if (jump)
            anim.SetTrigger(jumpTrigger);
    }
}
