using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{

    public TMP_Text textTMP;
    public TMP_Text nameTMP;

    private GameObject robot;

    private string name;
    private string text;

    private bool show;

    public Camera _camera;

    private static GameObject dialogWindow;
    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.Find("Banana Man");
        dialogWindow = GameObject.Find("Dialog");
        Desactivate();
    }

    public static void Activate()
    {
        dialogWindow.transform.position = new Vector3(546, 115, 0); //переделать на новом месте
    }

    public static void Desactivate()
    {
        dialogWindow.transform.position = new Vector3(-1000, -1000, -1000);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            show = false;
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var distance = Vector3.Distance(hit.transform.position, robot.transform.position);
                Debug.Log(distance);
                if (hit.transform.GetComponent<ItemClicked>() && distance < 1.5)
                {
                    text = hit.transform.GetComponent<ItemClicked>().text;
                    name = hit.transform.GetComponent<ItemClicked>().name;
                    show = true;
                }
            }

            textTMP.text = text;
            nameTMP.text = name;

            if (show)
            {
                Activate();
                Debug.Log(dialogWindow.transform.position);
            }
            else
            {
                Desactivate();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Desactivate();

        }
    }
}
