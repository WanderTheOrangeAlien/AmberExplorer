using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvas_AmberHandler : MonoBehaviour
{

    public TMP_Text counterText;
    public GameObject UI;
    public bool isUIActivated;

    //Statiic event so that we can call it with public static methods
    public delegate void ToggleUIDelegate();
    public static event ToggleUIDelegate OnToggleUI;


    private void Start()
    {
    }

    private void Update()
    {
        counterText.text = "x" + PlayerInventory.Instance.amberAmount.ToString();
    }

    public static void InvokeToggleUI()
    {
        OnToggleUI();
    }

    public void ToggleUI()
    {

    }
}

[System.Serializable]
public struct AmberDisplayMsg_t
{
    public GameObject parent;
    public TMP_Text title;
    public TMP_Text description;
    public TMP_Text probability;

}
