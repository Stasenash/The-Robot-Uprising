using UnityEngine;

public class FridgeInterraction : MonoBehaviour
{
    public GameObject fridge;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 2; i < 12; ++i)
        {
		    fridge.transform.GetChild(i).gameObject.SetActive(false);
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnMouseDown()
	{
        fridge.transform.GetChild(0).gameObject.SetActive(false);
		fridge.transform.GetChild(1).gameObject.SetActive(false);
		for (int i = 2; i < 12; ++i)
		{
			fridge.transform.GetChild(i).gameObject.SetActive(true);
		}
	}
}
