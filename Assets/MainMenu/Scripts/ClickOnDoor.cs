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

    private bool show;
    void Start()
    {
        dialogWindow = GameObject.Find("Dialog");
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        if (Stats.isItemsReturned)
        {
            SceneManager.LoadScene(3);
        }
        else 
        {
            //var fields = dialogWindow.GetComponentsInChildren<TMP_Text>();
            //fields[0].text = names[0];
            //fields[1].text = replics[0];
            //show = true;
            var audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            return;
        }
    }
}
