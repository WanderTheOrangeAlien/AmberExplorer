using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Canvas_TimeSelectionButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Canvas_TimeSelectionV2 CanvasHandler;
    public int id;
    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Do something.
        Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
        CanvasHandler.HighlightOption(id);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("<color=red>Event:</color> Completed mouse exit.");
        CanvasHandler.UnhighlightOption(id);
    }

    // When selected.
    public void OnSelect(BaseEventData eventData)
    {
        // Do something.
        Debug.Log("<color=red>Event:</color> Completed selection.");
    }
}
