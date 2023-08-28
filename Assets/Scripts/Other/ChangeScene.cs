using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entró en el trigger: " + other.gameObject.name);
        if (other.name == "XR Origin")
        {

            SceneManager.LoadScene("Example");
        }
        // Aquí puedes realizar cualquier acción que desees cuando un objeto entre en el trigger
    }
}
