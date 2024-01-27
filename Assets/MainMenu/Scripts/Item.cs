using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public bool isDeletable;
    public int id;
    public Sprite sprite;
    public bool picked;

    public Item(string name, int id, Sprite sprite, bool isDeletable, bool picked)
    {
        Name=name;
        this.id=id;
        this.sprite=sprite;
        this.isDeletable=isDeletable;
        this.picked=picked;
    }
}
