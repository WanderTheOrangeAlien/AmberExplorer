using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEventExit : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject XRController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "XR Origin (2)")
        {
            Settings.Instance.SalidaCheck = true;
            Settings.Instance.EntradaCheck = false;
            XRController.SetActive(false);
        }
    }


}
