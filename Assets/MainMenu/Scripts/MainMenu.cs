using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter!");
        renderer.material.color = Color.yellow;
        renderer.GetComponentInChildren<TextMeshPro>().color = Color.white;
        
    }
    private void OnMouseExit()
    {
        Debug.Log("Exit!");
        renderer.material.color = Color.white;
        renderer.GetComponentInChildren<TextMeshPro>().color = Color.black;
    }

    private void OnMouseDown()
    {
        if (renderer.tag == "Exit")
        {
            Application.Quit();
        }
        if (renderer.tag == "StartGame")
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}
