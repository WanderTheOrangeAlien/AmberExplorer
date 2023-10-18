using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class transicion : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneTransition x;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "XR Origin" && GameManager.Instance.isHarnessOn)
        {
            Debug.Log("Listo para entrar");
            TimerController.StartTimer();

            // SceneManager.LoadScene("Example");
            x.ChangeScene(3, "CaveScene");

            other.gameObject.GetComponent<DynamicMoveProvider>().enabled = false;

        }

        // Aquí puedes realizar cualquier acción que desees cuando un objeto entre en el trigger
    }
}
