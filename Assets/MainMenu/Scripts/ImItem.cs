using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImItem : MonoBehaviour
{
    public string Name;
    public Sprite sprite;

    public ImItem(string name, Sprite sprite)
    {
        Name=name;
        this.sprite=sprite;
    }
}
