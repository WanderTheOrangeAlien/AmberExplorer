using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notificationSocket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Chaleco;
    public GameObject Casco;
    public GameObject XRController;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OntriggerEnter(Collider other)
    {
        if (other.gameObject == Casco)
        {
            Debug.Log("El objeto específico entró en la zona.");
            // Realiza cualquier acción adicional que necesites aquí
            Settings.Instance.checkKeyCasco = true;
            Settings.Instance.GlobalAudio = true;
            XRController.SetActive(false);

        }
        if (other.gameObject == Chaleco)
        {
            Debug.Log("El objeto específico entró en la zona.");
            // Realiza cualquier acción adicional que necesites aquí
            Settings.Instance.checkKeyChaleco = true;
            Settings.Instance.GlobalAudio = true;
            XRController.SetActive(false);


        }
        // if (other.name == "Security hat")
        // {

        //     Settings.Instance.checkKeyCasco = true;
        // }
        // if (other.name == "chaleco con hueso2")
        // {

        //     Settings.Instance.checkKeyChaleco = true;
        // }


    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == Casco)
        {
            Debug.Log("El objeto específico SAlio en la zona.");
            // Realiza cualquier acción adicional que necesites aquí
            Settings.Instance.checkKeyCasco = false;
        }
        if (other.gameObject == Chaleco)
        {
            Debug.Log("El objeto específico SAlio en la zona.");
            // Realiza cualquier acción adicional que necesites aquí
            Settings.Instance.checkKeyChaleco = false;
        }
        // if (other.name == "chaleco con hueso2")
        // {
        //     Debug.Log("Otro objeto salió del trigger: " + other.name);
        //     Settings.Instance.checkKeyChaleco = false;
        // }
        // Realiza cualquier acción adicional que necesites aquí
    }
}
