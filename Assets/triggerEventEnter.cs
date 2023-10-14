using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEventEnter : MonoBehaviour
{
    public GameObject XRController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "XR Origin (2)")
        {
            Settings.Instance.EntradaCheck = true;
            Settings.Instance.SalidaCheck = false;

            XRController.SetActive(true);
            if (Settings.Instance.GlobalAudio == true)
            {
                XRController.SetActive(false);
            }
        }
    }
}
