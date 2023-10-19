using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public GameObject panelESP;
    public GameObject panelENG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panelESP.SetActive(GlobalSettings.Instance.language == Language.Espanol);
        panelENG.SetActive(GlobalSettings.Instance.language == Language.English);
    }
}
