using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour, IPointerClickHandler
{
    public GameObject cellContainer;
    public int Index;
    public string activeItemName;
    private List<string> cells;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (cellContainer.transform.GetChild(Index) != null)
            {
                activeItemName = cellContainer.transform.GetChild(Index).name;
                if (cells.Contains(activeItemName))
                {
                    return;
                }
                //взаимодействие с другими предметами
                if (Stats.ActiveItem != null)
                {
                    activeItemName = null;
                    Stats.ActiveItem = null;
                    cellContainer.transform.GetChild(Index).GetComponent<Image>().color = Color.white;
                }
                else
                {
                    cellContainer.transform.GetChild(Index).GetComponent<Image>().color = Color.red;
                    Stats.ActiveItem = activeItemName;
                }
            }
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

    void DeleteItem()
    {
        cellContainer.transform.GetChild(Index).GetComponent<Image>().sprite = null;
        cellContainer.transform.GetChild(Index).GetComponent<Image>().name = "Cell" + Index;
    }

    void AddItem()
    {

        //идем по cellContainer и ищем первую ячейку с названием Селл+i
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
