using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArnessEventHandler : MonoBehaviour
{
    XRSocketInteractor socketInteractor;
    // Start is called before the first frame update
    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener((args) =>
        {
            GameManager.Instance.isHarnessOn = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
