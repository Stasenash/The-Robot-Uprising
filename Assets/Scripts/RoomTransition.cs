using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomTransition : MonoBehaviour
{
    public GameObject currentCamera;
    public GameObject newCamera;

    private NavMeshAgent nva;

    private GameObject robot;

    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.Find("Banana Man");
        nva = robot.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnMouseDown()
	{
        string[] name = gameObject.name.Split(' ');

        //if (name.Length == 2)
        //{
        //    Debug.Log(name[0]);
        //    return;
        //}

        switch (name[1])
        {
            case "Bathroom":
                nva.enabled = false;
                robot.transform.position = new Vector3(-903.0f, 0.1f, 170.0f); nva.enabled = true;
                break;
            case "MainRoom": nva.enabled = false; robot.transform.position = new Vector3(6.0f, 0.1f, 5.2f); nva.enabled = true; break;
            case "Kitchen": nva.enabled = false; robot.transform.position = new Vector3(39.0f, 0.1f, -425.0f); nva.enabled = true; ; break;
            case "Bedroom": nva.enabled = false; robot.transform.position = new Vector3(230.0f, 0.1f, 158.0f); nva.enabled = true; ; break;
            case "Door":;break;//переход на катсцену ивентов при условии
        }

        currentCamera.SetActive(false);
        newCamera.SetActive(true);
	}
}
