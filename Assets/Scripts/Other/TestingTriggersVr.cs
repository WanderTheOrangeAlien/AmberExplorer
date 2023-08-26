using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTriggersVr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("LeftHand")) // Asume que has etiquetado tu mano izquierda con el tag "LeftHand"
        {
            // Haz algo cuando la mano izquierda entra en el trigger
        }
        else if (other.CompareTag("RightHand"))
        {
            // Haz algo cuando la mano derecha entra en el trigger
        }
    }
}
