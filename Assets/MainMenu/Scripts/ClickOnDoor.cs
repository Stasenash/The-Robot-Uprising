using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOnDoor : MonoBehaviour
{
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
        if (cd > 0) cd -= (int) (Time.deltaTime * 1000);
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
        if (Stats.isItemsReturned)
        {
            SceneManager.LoadScene(3);
        }
        if (Stats.bottleGasOnMan)
        {
            SceneManager.LoadScene(5);
        }
        else 
        {
            var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            fields[0].text = names[0];
            fields[1].text = replics[0];
            hideOnLB = true;
            cd = cooldown;
            Activate();
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
