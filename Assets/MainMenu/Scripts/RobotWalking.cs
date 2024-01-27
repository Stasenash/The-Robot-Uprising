using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotWalking : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    public static Animator anim;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                anim.Play("Walking");
                myAgent.speed = 4.0f;
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
