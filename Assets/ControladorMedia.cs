using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMedia : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource omitirTutorial;
    public AudioClip audioClip;

    public Material v;
    public Material vv;


    public float amplitude = 1f;  // Amplitud del movimiento
    public float frequency = 1.0f;  // Frecuencia del movimiento

    public float phase = -0.9663037f;
    private bool actionDone = false;

    void Start()
    {
        if (omitirTutorial == null)
        {
            omitirTutorial = GetComponent<AudioSource>();
        }

        PlayAudio();
    }

    void PlayAudio()
    {
        if (omitirTutorial != null && audioClip != null)
        {

            omitirTutorial.clip = audioClip;
            omitirTutorial.Play();


        }
    }

    void Update()
    {
        if (omitirTutorial.time >= 4 && !actionDone)
        {
            // Haz algo aquí
            Debug.Log("Hemos llegado al segundo específico: " + 3);

            // Marca la acción como realizada para que no se repita


            float time2 = Time.time;


            float offset = Mathf.Sin(time2 * frequency - phase) * amplitude;
            Debug.Log(offset);
            Debug.Log(time2);

            v.SetFloat("_MeshTransparent", offset);
            vv.SetFloat("_MeshTransparent", offset);


            if (omitirTutorial.time >= 9 && Time.time >= 10)
            {

                Debug.Log("Hemos llegado al segundo específico: " + 9);

                actionDone = true;

            }
        }

        if (!omitirTutorial.isPlaying && !Settings.Instance.EnableVideos)
        {
            // QuadVideo.SetActive(true);
        }


    }

}
