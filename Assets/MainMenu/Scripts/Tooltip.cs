using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
	public static string text;
	public static bool isUI;

	public Color textColor = Color.black;
	public Color BGColor = Color.white;
	public enum ProjectMode { Tooltip3D = 0, Tooltip2D = 1 };
	public ProjectMode tooltipMode = ProjectMode.Tooltip3D;

	public TMP_Text boxText;
	public float speed = 10; // скорость плавного затухания и проявления

	private GameObject robot;
	//public Camera _camera;

	private Color BGColorFade;
	private Color textColorFade;

	private Vector3 pos;

	void Awake()
	{
		robot = GameObject.Find("Banana Man");
		BGColorFade = BGColor;
		BGColorFade.a = 0;
		textColorFade = textColor;
		textColorFade.a = 0;
		isUI = false;
	}

	void LateUpdate()
	{
		bool show = false;

		if (tooltipMode == ProjectMode.Tooltip3D)
		{
			RaycastHit hit;
			Camera camera = GetCamera();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.GetComponent<ToolTipText>())
				{
					text = hit.transform.GetComponent<ToolTipText>().text;
					pos = Input.mousePosition;
					show = true;
				}
			}
		}

		boxText.text = text;

		if (show || isUI)
		{
			boxText.transform.position = new Vector3(pos.x + 150, pos.y, pos.z);
			boxText.color = Color.Lerp(boxText.color, textColor, speed * Time.deltaTime);
		}
		else
		{
			boxText.transform.position = new Vector3(pos.x + 150, pos.y, pos.z);
			boxText.color = Color.Lerp(boxText.color, textColorFade, speed * Time.deltaTime);
		}
	}

	Camera GetCamera()
	{
		if (GameObject.Find("Bathroom Camera") != null) return GameObject.Find("Bathroom Camera").GetComponent<Camera>();
		if (GameObject.Find("Bedroom Camera") != null) return GameObject.Find("Bedroom Camera").GetComponent<Camera>();
		if (GameObject.Find("Kitchen Camera") != null) return GameObject.Find("Kitchen Camera").GetComponent<Camera>();
		if (GameObject.Find("MainRoom Camera") != null) return GameObject.Find("MainRoom Camera").GetComponent<Camera>();
		return null;
	}
}
