using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public static List<Item> items;

    public GameObject cellContainer;
    public KeyCode showInventory;

    private GameObject robot;

    void Start()
    {
        robot = GameObject.Find("Banana Man");
        cellContainer.SetActive(false);
        items = new List<Item>();
        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            items.Add(new Item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowInventory();
        TakeItem();
        
    }

    void ShowInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
            }
            else
            {
                cellContainer.SetActive(true);
            }
        }
    }

    void TakeItem() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var distance = Vector3.Distance(hit.transform.position, robot.transform.position);
                if (hit.collider.GetComponent<Item>() && distance < 1.5)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].id == 0)
                        {
                            items[i] = hit.collider.GetComponent<Item>();
                            DisplayItems();
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            break;
                        }
                    }
                }
            }

        }
    }

    void DisplayItems()
    {
        for (int i = 0; i< items.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Image img = cell.GetComponent<Image>();
            if (items[i].id > 0)
            {
                img.enabled = true;
                img.sprite = items[i].sprite;
                cellContainer.transform.GetChild(i).name = items[i].name;
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
            }
            else
            {
                img.sprite = null;
                img.enabled = false;
                cellContainer.transform.GetChild(i).name = "Cell" + i;
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0.2f);
            }
        }
    }
}
