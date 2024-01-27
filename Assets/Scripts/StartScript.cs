using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject mainRoomCamera, bedroomCamera, bathroomCamera, kitchenCamera;

    // Start is called before the first frame update
    void Start()
    {
		mainRoomCamera.SetActive(true);
		bedroomCamera.SetActive(false);
		bathroomCamera.SetActive(false);
		kitchenCamera.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
