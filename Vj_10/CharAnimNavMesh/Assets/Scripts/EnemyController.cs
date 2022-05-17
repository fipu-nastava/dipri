using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    private static readonly int SpeedFloat = Animator.StringToHash("Speed");

    private NavMeshAgent navAgent;
    private Animator animator;


    // Transform component of the gameObject we are following
    private Transform following;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Current speed divided by the max speed
        // This will result tu [0-1]
        float velocity = navAgent.velocity.magnitude / navAgent.speed;

        // Update the animator Speed parameter
        animator.SetFloat(SpeedFloat, velocity);

        // This is now an ideal solution as we are updating the destination
        // on each update function, but will do just enough for our example
        if (following)
            navAgent.SetDestination(following.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // When the player enters our collider set him as a target
        if (other.CompareTag("Player"))
            following = other.gameObject.transform;

    }
    void OnTriggerExit(Collider other)
    {
        // When the player escapes we are no longer following him
        if (other.CompareTag("Player"))
            following = null;
    }

}
