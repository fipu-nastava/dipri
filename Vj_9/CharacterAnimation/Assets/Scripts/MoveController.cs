using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MoveController requires the GameObject to have a Animator component
[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{
    public string SprintButton = "Sprint"; // Name set under Edit->Project Settings-> Input Managers
    public string JumpButton = "Jump";

    static readonly int forwardFloat = Animator.StringToHash("Forward");
	static readonly int jumpTrigger = Animator.StringToHash("Jump");

    static readonly int jumpState = Animator.StringToHash("Jump");

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
        var jump = Input.GetButtonDown(JumpButton);
        // Only set the trigger when the next animation is not already set to jump
        // or when we are already in jump animation
        // Setting the trigger without this conditions will result in multiple jump
        // sequences when the space button is pressed multiple times
        // before or during the jump animation
        if (jump && anim.GetNextAnimatorStateInfo(0).shortNameHash != jumpState
            && anim.GetCurrentAnimatorStateInfo(0).shortNameHash != jumpState)
            anim.SetTrigger(jumpTrigger);
    }
}
