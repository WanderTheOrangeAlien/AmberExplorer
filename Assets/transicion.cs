using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.name == "XR Origin (2)")
        {
            Debug.Log("Listo para entrar");
            if (Settings.Instance.language == Language.Espanol)
            {
                TimerController.StartTimer();

                // SceneManager.LoadScene("Example");
                x.ChangeScene(3, "Example");
            }
            if (Settings.Instance.language == Language.English)
            {
                TimerController.StartTimer();

                // SceneManager.LoadScene("Example");
                x.ChangeScene(3, "Example");
            }


        }

        // Aquí puedes realizar cualquier acción que desees cuando un objeto entre en el trigger
    }
}
