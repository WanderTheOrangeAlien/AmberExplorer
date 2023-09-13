using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Settings.Instance.checkKeyCasco && Settings.Instance.checkKeyChaleco)
        {
            Debug.Log("Listo para entrar");
        }
        else
        {
            Debug.Log("NO");
        }
    }

    void OntriggerEnter(Collider other)
    {
        Debug.Log("Entro: " + other.name);

    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    public AudioSource audioManagerAdvertencia;
    public AudioClip audioAdvertenciaESP;
    public AudioClip audioAdvertenciaENG;
    public AudioClip audioFinalESP;
    public AudioClip audioFinalENG;
    // Start is called before the first frame update

    void Start()
    {
        if (audioManagerAdvertencia == null)
        {
            audioManagerAdvertencia.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OntriggerEnter(Collider other)
    {
        if (Settings.Instance.checkKeyCasco && Settings.Instance.checkKeyChaleco)
        {
            Debug.Log("Listo para entrar");
            if (Settings.Instance.language == Language.Espanol)
            {
                audioManagerAdvertencia.clip = audioFinalESP;
                audioManagerAdvertencia.Play();

            }
            else if (Settings.Instance.language == Language.English)
            {
                audioManagerAdvertencia.clip = audioFinalENG;
                audioManagerAdvertencia.Play();
            }

        }
        else
        {
            Debug.Log("Mensaje de advertencia");
            if (Settings.Instance.language == Language.Espanol)
            {
                audioManagerAdvertencia.clip = audioAdvertenciaESP;
                audioManagerAdvertencia.Play();

            }
            else if (Settings.Instance.language == Language.English)
            {
                audioManagerAdvertencia.clip = audioAdvertenciaENG;
                audioManagerAdvertencia.Play();
            }
        }


    }
}
*/