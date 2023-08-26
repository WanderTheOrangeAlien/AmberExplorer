using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvas_AmberHandler : MonoBehaviour
{
    public AmberDisplayMsg_t amberDisplayMsg;

    // Start is called before the first frame update
    void Start()
    {
        
        AmberComponent.OnAmberCollected += DisplayAmberCollected;
        amberDisplayMsg.parent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayAmberCollected(AmberScriptableObject amberData)
    {
        amberDisplayMsg.parent.SetActive(true);
        //amberDisplayMsg.description.text = _amberInfo.description;
        amberDisplayMsg.title.text = amberData.amberType.ToString();

        Debug.Log("Ambar Recolectado: " + amberData.amberType.ToString());


        switch (amberData.amberType)
        {
            case AmberType.Miel:

                break;

            case AmberType.Naranja:

                break;

            case AmberType.Rojo:

                break;

            case AmberType.Azul:

                break;
        }
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
