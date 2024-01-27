using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public GameObject currentCamera;
    public GameObject newCamera;

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnMouseDown()
	{
        string[] name = gameObject.name.Split(' ');

        if (name.Length == 2)
        {
            Debug.Log(name[0]);
            return;
        }

        currentCamera.SetActive(false);
        newCamera.SetActive(true);
	}
}
