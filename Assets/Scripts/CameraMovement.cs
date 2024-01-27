using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#pragma warning disable 0169, 0414, anyothernumber

public class CameraMovement : MonoBehaviour
{
    public float cameraMoveSpeed = 0.3f;
	public float objectsMoveSpeed = 0.1f;
    public float centerX = 0f;
	public float centerZ = 0f;
    public int coolDown = 500;

	public string roomName;
    public Transform cameraObj;

    private const float angle_rotation = 90.0f;
	private const float delta = 0.0000001f;

	private bool isMoving = false;
    private int direction;
    private float anglesLeft;
    private int currentCoolDown = 0;

	private GameObject[] hiddenObjects, shownObjects;

	// Start is called before the first frame update
	void Start()
    {
		float x = cameraObj.position.x - centerX;
		float z = cameraObj.position.z - centerZ;

		string hiddenWallXTag = "Wall ";
		string hiddenWallZTag = "Wall ";
		string hiddenObjXTag  = "Near Wall ";
		string hiddenObjZTag  = "Near Wall ";

		hiddenWallXTag += "X" + (x < 0 ? "-" : "+");
		hiddenWallZTag += "Z" + (z < 0 ? "-" : "+");
		hiddenObjXTag  += "X" + (x < 0 ? "-" : "+");
		hiddenObjZTag  += "Z" + (z < 0 ? "-" : "+");

		hiddenObjects = GameObject.FindGameObjectsWithTag(hiddenWallXTag).Concat(GameObject.FindGameObjectsWithTag(hiddenObjXTag)).ToArray()
			.Concat(GameObject.FindGameObjectsWithTag(hiddenWallZTag)).ToArray().Concat(GameObject.FindGameObjectsWithTag(hiddenObjZTag)).ToArray();
		foreach (var obj in hiddenObjects)
		{
			if (obj.layer == LayerMask.NameToLayer(roomName))
			{
				obj.transform.position += new Vector3(0, objectsMoveSpeed * Mathf.CeilToInt(angle_rotation / cameraMoveSpeed), 0);
			}
		}

		//Debug.Log(roomName + " walls went up");
	}

    // Update is called once per frame
    void Update()
    {
        if (cameraObj.gameObject.active && (isMoving || currentCoolDown <= 0 && (Input.GetKey("q") || Input.GetKey("e"))))
        {
            if (!isMoving)
            {
                isMoving = true;
                anglesLeft = angle_rotation;
                direction = Input.GetKey("q") ? -1 : 1;
                currentCoolDown = coolDown;

                float x = cameraObj.position.x - centerX;
                float z = cameraObj.position.z - centerZ;

                string hiddenWallTag = "Wall ";
                string shownWallTag  = "Wall ";

                if (direction == -1)
                {
					hiddenWallTag += x * z < 0 ? "X" : "Z";
					hiddenWallTag += x < 0 ? "+" : "-";
					shownWallTag  += x * z < 0 ? "X" : "Z";
					shownWallTag  += x < 0 ? "-" : "+";
				} else
                {
					hiddenWallTag += x * z < 0 ? "Z" : "X";
					hiddenWallTag += z < 0 ? "+" : "-";
					shownWallTag  += x * z < 0 ? "Z" : "X";
					shownWallTag  += z < 0 ? "-" : "+";
				}

				hiddenObjects = GameObject.FindGameObjectsWithTag(hiddenWallTag).Concat(GameObject.FindGameObjectsWithTag("Near " + hiddenWallTag)).ToArray();
				shownObjects = GameObject.FindGameObjectsWithTag(shownWallTag).Concat(GameObject.FindGameObjectsWithTag("Near " + shownWallTag)).ToArray();
			}

			if (anglesLeft < delta)
			{
				isMoving = false;
			}
			else
			{
				float cos = Mathf.Cos(direction * Mathf.PI / 180 * Mathf.Min(anglesLeft, cameraMoveSpeed));
				float sin = Mathf.Sin(direction * Mathf.PI / 180 * Mathf.Min(anglesLeft, cameraMoveSpeed));

				float radX = cameraObj.position.x - centerX;
				float radZ = cameraObj.position.z - centerZ;

				float x = centerX + radX * cos - radZ * sin;
				float z = centerZ + radX * sin + radZ * cos;

				cameraObj.position = new Vector3(x, cameraObj.position.y, z);
				cameraObj.RotateAround(new Vector3(0, 1, 0), -direction * Mathf.Min(anglesLeft, cameraMoveSpeed) / 180 * Mathf.PI);
				
				anglesLeft -= cameraMoveSpeed;

				foreach (var obj in shownObjects)
				{
					if (obj.layer == LayerMask.NameToLayer(roomName))
					{
						//Debug.Log(obj.layer);
						//Debug.Log(LayerMask.NameToLayer(roomName));
						obj.transform.position -= new Vector3(0, objectsMoveSpeed, 0);
					}
				}

				foreach (var obj in hiddenObjects)
				{
					if (obj.layer == LayerMask.NameToLayer(roomName))
					{
						//Debug.Log(obj.layer);
						//Debug.Log(LayerMask.NameToLayer(roomName));
						obj.transform.position += new Vector3(0, objectsMoveSpeed, 0);
					}
				}
			}
		}

        if (currentCoolDown > 0) currentCoolDown -= (int) (Time.deltaTime * 1000); 
	}
}
