using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Since we are using only one camera we can access it using Camera.main
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Placeholder for a clicked position
            RaycastHit hit;

            // This create a ray (line) from camera to the click position and
            // checks if we hit something (a gameObject) with our mouse click

            // If true, hit variable will be initialized with information about the hit point
            if (Physics.Raycast(ray, out hit))
            {
                // Set the new destination for the agent
                agent.SetDestination(hit.point);
            }
        }
    }
}
