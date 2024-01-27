using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickOnTV : MonoBehaviour
{
    private GameObject dialogWindow;
    int index = 0;

    public string[] replics;
    public string[] names;

    private bool show;
    public int cooldown = 10000;
    private int currentCooldown;

    private bool dialogStarted;

    void Start()
    {
        dialogWindow = GameObject.Find("Dialog");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.layer);
                if (hit.transform.gameObject.layer == 3)
                {
                    show = false;
                }
            }
        }
        if (show)
        {
            Activate();
        }
        else
        {
            Desactivate();
        }
    }

    void OnMouseDown()
    {
        //show = false;
        Debug.Log("Here!");
        Debug.Log(show);
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
            show = true;
            index++;
            return;
        }
        else if (index < 4)
        {
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[index];
            fields[1].text = replics[index];
            show = true;
            index++;
            return;
        }
        else
        {
            if (Stats.isFlash1 && Stats.isFlash2 && Stats.isFlash3 && Stats.isFlash4)
            {
                var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
                fields[0].text = names[5];
                fields[1].text = replics[5];
                show = true;
                Stats.isItemsReturned = true;
                return;
            }
            else
            {
                var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
                fields[0].text = names[4];
                fields[1].text = replics[4];
                show = true;
                return;
            }
        }

    }

    void Activate()
    {
        dialogWindow.transform.position = new Vector3(644, 140, 0); //���������� �� ����� �����
    }

    void Desactivate()
    {
        dialogWindow.transform.position = new Vector3(-1000, -1000, -1000);
    }
}
