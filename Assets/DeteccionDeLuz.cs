using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeteccionDeLuz : MonoBehaviour
{

    public static int indexMaterial;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ambar"))
        {
            Transform parentTransform = other.transform;

            Transform childTransform = parentTransform.Find("5_amber_lr");

            if (childTransform != null)
            {
                indexMaterial = 1;


            }

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Ambar"))
        {
            Transform parentTransform = other.transform;

            Transform childTransform = parentTransform.Find("5_amber_lr");

            if (childTransform != null)
            {
                indexMaterial = 0;
            }

        }
    }
}
