using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickOnBooks : MonoBehaviour
{
    private bool second;
    private GameObject dialogWindow;
    int index = 0;

    public string[] replics;
    public string[] names;

    public int cooldown = 500;
    private int cd;

    private bool hideOnLB;
    void Start()
    {
        dialogWindow = GameObject.Find("Dialog");
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

    // Update is called once per frame

    void OnMouseDown()
    {
        if (!second)
        {
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[0];
            fields[1].text = replics[0];
            hideOnLB = true;
            cd = cooldown;
            second = true;
            Activate();
            var audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            return;
        }
        return;
    }

    public void Activate()
    {
        Debug.Log("aktive");
        dialogWindow.transform.position = new Vector3(644, 140, 0); //переделать на новом месте
    }

    public void Desactivate()
    {
        dialogWindow.transform.position = new Vector3(-1000, -1000, -1000);
    }
}
