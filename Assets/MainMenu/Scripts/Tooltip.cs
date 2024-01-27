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
	public float speed = 10; // �������� �������� ��������� � ����������

	private GameObject robot;
	public Camera _camera;

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
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
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
			boxText.transform.position = pos;
			boxText.color = Color.Lerp(boxText.color, textColor, speed * Time.deltaTime);
		}
		else
		{
			boxText.transform.position = pos;
			boxText.color = Color.Lerp(boxText.color, textColorFade, speed * Time.deltaTime);
		}
	}
}
