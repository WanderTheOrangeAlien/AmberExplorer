using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLanguageUIHandler : MonoBehaviour
{

    public GameObject ESP;
    public GameObject ENG;
    // Start is called before the first frame update
    void Start()
    {
        ESP.SetActive(GlobalSettings.Instance.language == Language.Espanol);
        ENG.SetActive(GlobalSettings.Instance.language == Language.English);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
