using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TooltipTextUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	public string text;

	void IPointerEnterHandler.OnPointerEnter(PointerEventData e)
	{
		Tooltip.text = text;
		Tooltip.isUI = true;
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData e)
	{
		Tooltip.isUI = false;
	}
}
