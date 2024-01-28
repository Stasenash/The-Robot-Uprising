using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour, IPointerClickHandler
{
    public GameObject cellContainer;
    public int Index;
    private List<string> cells;

    private string activeItemName;
    private Sprite activeItemSprite;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pointer");
        Debug.Log(Stats.ActiveItemName);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (cellContainer.transform.GetChild(Index) != null)
            {
                var activeItemC = cellContainer.transform.GetChild(Index);
                var activeItemCopy = activeItemC.GetComponent<Image>();
                activeItemName = activeItemCopy.name;
                activeItemSprite = activeItemCopy.sprite;
                //взаимодействие с другими предметами
                if (Stats.ActiveItemName != null)
                {
                    if (Stats.ActiveItemName == activeItemName)
                    {
                        Stats.ActiveItemName = null;
                        Stats.ActiveItemSprite = null;
                        cellContainer.transform.GetChild(Index).GetComponent<Image>().color = new Color(255, 255, 255, 1f);
                        return;
                    }
                    CheckInteractions();
                    activeItemName = null;
                    activeItemName = null;
                    Stats.ActiveItemName = null;
                    Stats.ActiveItemSprite = null;
                    cellContainer.transform.GetChild(Index).GetComponent<Image>().color = new Color (255,255,255,0.2f);
                }
                else
                {
                    cellContainer.transform.GetChild(Index).GetComponent<Image>().color = Color.red;
                    Stats.ActiveItemName = activeItemName;
                    Stats.ActiveItemSprite = activeItemSprite;
                }
            }
        }
    }
    void CheckInteractions()
    {
        Debug.Log(Stats.ActiveItemName);
        switch(Stats.ActiveItemName)
        {
            case "kettle":
                if (activeItemName == "kitchenCabinetUpperLow") 
                {
                    for (int i = 0; i < cellContainer.transform.childCount; i++)
                    {
                        Transform cell = cellContainer.transform.GetChild(i);
                        Image img = cell.GetComponent<Image>();
                        if (cell.name.Contains("Cell"))
                        {
                            img.enabled = true;
                            img.sprite = Stats.ActiveItemSprite;
                            cellContainer.transform.GetChild(i).name = "kettleWithBeans";
                            img.color = new Color(255f, 255f, 255f, 1f);
                            break;
                        }
                    }
                    for (int i = 0; i < cellContainer.transform.childCount; i++)
                    {
                        Transform cell = cellContainer.transform.GetChild(i);
                        Image img = cell.GetComponent<Image>();
                        if (cell.name == "kettle" || cell.name == "kitchenCabinetUpperLow")
                        {
                            img.sprite = null;
                            Stats.ActiveItemSprite = null;
                            Stats.ActiveItemName = null;
                            cellContainer.transform.GetChild(i).name = "Cell" + i;
                            img.color = new Color(255f, 255f, 255f, 0.2f);
                        }
                    }
                    Stats.kettleWithBeans = true;
                } ;break;
            case "kitchenCabinetUpperLow":
                if (activeItemName == "kettle")
                {
                    for (int i = 0; i < cellContainer.transform.childCount; i++)
                    {
                        Transform cell = cellContainer.transform.GetChild(i);
                        Image img = cell.GetComponent<Image>();
                        if (cell.name.Contains("Cell"))
                        {
                            img.enabled = true;
                            img.sprite = Stats.ActiveItemSprite;
                            cellContainer.transform.GetChild(i).name = "kettleWithBeans";
                            img.color = new Color(255f, 255f, 255f, 1f);
                            break;
                        }
                    }
                    for (int i = 0; i < cellContainer.transform.childCount; i++)
                    {
                        Transform cell = cellContainer.transform.GetChild(i);
                        Image img = cell.GetComponent<Image>();
                        if (cell.name == "kettle" || cell.name == "kitchenCabinetUpperLow")
                        {
                            img.sprite = null;
                            Stats.ActiveItemSprite = null;
                            Stats.ActiveItemName = null;
                            cellContainer.transform.GetChild(i).name = "Cell" + i;
                            img.color = new Color(255f, 255f, 255f, 0.2f);
                        }
                    }
                    Stats.kettleWithBeans = true;
                }; break;
            default:break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cells = new List<string>();
        for (int i = 0; i < 10; i++) 
        {
            cells.Add("Cell" + i);
        }
        
        cellContainer = GameObject.Find("InventoryPanel");
    }

}
