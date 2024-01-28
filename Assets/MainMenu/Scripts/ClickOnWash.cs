using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnWash : MonoBehaviour
{
    private GameObject dialogWindow;
    int index = 0;

    public string[] replics;
    public string[] names;

    public int cooldown = 500;
    private int cd;

    private bool hideOnLB;
    private GameObject cellContainer;
    void Start()
    {
        dialogWindow = GameObject.Find("Dialog");
        cellContainer = GameObject.Find("InventoryPanel");
    }

    private void Update()
    {
        if (cd > 0) cd -= (int)(Time.deltaTime * 1000);
        if (Input.GetMouseButtonDown(0) && hideOnLB && cd <= 0)
        {
            Desactivate();
            hideOnLB = false;
            return;
        }
    }

    private void OnMouseDown()
    {
        if (Stats.ActiveItemName == "Bottle" || Stats.ActiveItemName == "bottleWithBeans")
        {
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[0];
            fields[1].text = replics[0];
            hideOnLB = true;
            cd = cooldown;
            Activate();
            for (int i = 0; i < cellContainer.transform.childCount; i++)
            {
                Transform cell = cellContainer.transform.GetChild(i);
                Image img = cell.GetComponent<Image>();
                if (cell.name.Contains("Cell"))
                {
                    img.enabled = true;
                    img.sprite = Stats.ActiveItemSprite;
                    cellContainer.transform.GetChild(i).name = "bottleGas";
                    img.color = new Color(255f, 255f, 255f, 1f);
                    break;
                }
            }
            for (int i = 0; i < cellContainer.transform.childCount; i++)
            {
                Transform cell = cellContainer.transform.GetChild(i);
                Image img = cell.GetComponent<Image>();
                if (cell.name == "Bottle" || cell.name == "bottleWithBeans")
                {
                    img.sprite = null;
                    Stats.ActiveItemSprite = null;
                    Stats.ActiveItemName = null;
                    Stats.kettleOnStove = true;
                    cellContainer.transform.GetChild(i).name = "Cell" + i;
                    img.color = new Color(255f, 255f, 255f, 0.2f);
                    break;
                }
            }

            var audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            return;
        }
    }
    public void Activate()
    {
        dialogWindow.transform.position = new Vector3(644, 140, 0); //переделать на новом месте
    }

    public void Desactivate()
    {
        dialogWindow.transform.position = new Vector3(-1000, -1000, -1000);
    }
}
