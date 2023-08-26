using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entró en el trigger: " + other.gameObject.name);
        SceneManager.LoadScene("Base Scene 1");
        // Aquí puedes realizar cualquier acción que desees cuando un objeto entre en el trigger
    }
}
