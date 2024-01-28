using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickOnVacuum : MonoBehaviour
{
    private GameObject dialogWindow;
    int index = 0;

    public string[] replics;
    public string[] names;

    public GameObject cellContainer;

    private bool finishDialog;

    void Start()
    {
        dialogWindow = GameObject.Find("Dialog");
        cellContainer = GameObject.Find("InventoryPanel");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Desactivate();
        }
    }

    void OnMouseDown()
    {
        if (finishDialog)
        {
            Desactivate();
            finishDialog = false;
            return;
        }
        if (index < 2)
        {
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[index];
            fields[1].text = replics[index];
            Activate();
            index++;

            if (index == 2)
            {
                finishDialog = true;
            }

            return;
        }
    }

    void Activate()
    {
        dialogWindow.transform.position = new Vector3(644, 140, 0); //переделать на новом месте
    }

    void Desactivate()
    {
        dialogWindow.transform.position = new Vector3(-1000, -1000, -1000);
    }
}
