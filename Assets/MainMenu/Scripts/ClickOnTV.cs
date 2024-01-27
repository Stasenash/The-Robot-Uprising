using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickOnTV : MonoBehaviour
{
    private GameObject dialogWindow;
    int index = 0;

    public string[] replics;
    public string[] names;

    private List<string> flashesNames;

    public GameObject cellContainer;

    private bool finishDialog;

    void Start()
    {
        dialogWindow = GameObject.Find("Dialog");
        cellContainer = GameObject.Find("InventoryPanel");
        flashesNames = new List<string>();
        flashesNames.Add("Flash1");
        flashesNames.Add("bookcaseClosedWide");
        flashesNames.Add("toiletSquare");
        flashesNames.Add("bedDouble");
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
        if (Stats.isItemsReturned)
        {
            return;
        }
        if (!Stats.isEventActive)
        {
            Stats.isEventActive = true;
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[index];
            fields[1].text = replics[index];
            Activate();
            index++;
            return;
        }
        else if (index < 4)
        {
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[index];
            fields[1].text = replics[index];
            Activate();
            index++;

            if (index == 4)
            {
                finishDialog = true;
            }

            return;
        }
        else
        {
            if (Stats.isFlash1 && Stats.isFlash2 && Stats.isFlash3 && Stats.isFlash4)
            {
                var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
                fields[0].text = names[5];
                fields[1].text = replics[5];
                Activate();
                Stats.isItemsReturned = true;
                DeleteFlashes();
                finishDialog = true;
                return;
            }
            else
            {
                var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
                fields[0].text = names[4];
                fields[1].text = replics[4];
                Activate();
                finishDialog = true;
                return;
            }
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

    void DeleteFlashes()
    {
        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            var cellItem = cellContainer.transform.GetComponent<CurrentItem>();
            Image img = cellContainer.transform.GetComponent<Image>();
            Debug.Log(flashesNames);
            if (flashesNames.Contains(cell.name))
            {
                img.sprite = null;
                img.enabled = false;
                cellContainer.transform.GetChild(i).name = "Cell" + i;
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0.2f);
            }
        }
    }
}
