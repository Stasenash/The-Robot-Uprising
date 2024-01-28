using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        var audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        return;
    }
}
