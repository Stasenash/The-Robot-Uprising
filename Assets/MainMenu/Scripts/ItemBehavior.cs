using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;

    private GameObject TVobj;
    private GameObject textTV;
    private GameObject see;
    private GameObject pickUp;
    private GameObject robot;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        TVobj = GameObject.Find("TVobj");
        textTV = GameObject.Find("TV");
        textTV.SetActive(false);
        see = GameObject.Find("see");
        see.SetActive(false);
        robot = GameObject.Find("Banana Man");
    }

    private void OnMouseEnter()
    {
        Debug.Log("OBJ Mouse Enter");
        textTV.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("OBJ Mouse Exit");
        textTV.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var distance = Vector3.Distance(TVobj.transform.position, robot.transform.position);
            if(distance < 1.4) 
            {
                see.SetActive(true);
            }
            else
            {
                see.SetActive(false);
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            see.SetActive(false);
            var distance = Vector3.Distance(TVobj.transform.position, robot.transform.position);
            if (distance < 1.4)
            {
                RobotWalking.anim.Play("PickUp");
                DestroyObject(TVobj,1);
            }
        }
    }
}
