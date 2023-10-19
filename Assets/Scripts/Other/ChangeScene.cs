using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public SceneTransition x;
    public AudioSource audioManagerAdvertencia;
    public AudioClip audioAdvertenciaESP;
    public AudioClip audioAdvertenciaENG;
    public AudioClip audioFinalESP;
    public AudioClip audioFinalENG;
    void Start()
    {
        x = FindObjectOfType<SceneTransition>();
        if (audioManagerAdvertencia == null)
        {
            audioManagerAdvertencia.GetComponent<AudioSource>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entró en el trigger: " + other.gameObject.name);
        if (other.name == "XR Origin (2)" && Settings.Instance.checkKeyCasco && Settings.Instance.checkKeyChaleco)
        {
            Debug.Log("Listo para entrar");
            if (GlobalSettings.Instance.language == Language.Espanol)
            {
                audioManagerAdvertencia.clip = audioFinalESP;
                audioManagerAdvertencia.Play();

                // SceneManager.LoadScene("Example");
                x.ChangeScene(3, "Example");
            }
            else if (GlobalSettings.Instance.language == Language.English)
            {
                audioManagerAdvertencia.clip = audioFinalENG;
                audioManagerAdvertencia.Play();
                x.ChangeScene(3, "Example");

            }

        }
        else if (other.name == "XR Origin (2)")
        {
            if (!Settings.Instance.checkKeyCasco || !Settings.Instance.checkKeyChaleco)
            {

                if (GlobalSettings.Instance.language == Language.Espanol)
                {
                    audioManagerAdvertencia.clip = audioAdvertenciaESP;
                    audioManagerAdvertencia.Play();

                }
                else if (GlobalSettings.Instance.language == Language.English)
                {
                    audioManagerAdvertencia.clip = audioAdvertenciaENG;
                    audioManagerAdvertencia.Play();
                }
            }
        }
        // Aquí puedes realizar cualquier acción que desees cuando un objeto entre en el trigger
    }
}
