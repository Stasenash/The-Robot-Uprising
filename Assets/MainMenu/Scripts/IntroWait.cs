using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroWait : MonoBehaviour
{
    public int waitSec;
    public int stage;
    void Start()
    {
       StartCoroutine(WaitForLevel());
    }

    IEnumerator WaitForLevel()
    {
        yield  return new WaitForSeconds(waitSec);
        SceneManager.LoadScene(stage);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(stage);
        }
    }
}
