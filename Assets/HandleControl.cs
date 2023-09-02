using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HandleControl : MonoBehaviour
{
    // Descripcion:
    // Este manejara todos los audios de la escena y los eventos relacionados.
    public GameObject ControlLeftControl;
    public GameObject ControlLeftHand;
    public GameObject ControlRightControl;
    public GameObject ControlRightHand;
    public GameObject RayLeft;
    public GameObject RayRight;  // Arrastra tu GameObject con el componente VideoPlayer aquí
    public AudioClip[] audioClips;
    private int currentClipIndex = 0;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource;

    // void Start()
    // {
    //     // ControlLeftHand.SetActive(false);
    //     // ControlRightHand.SetActive(false);
    //     // RayLeft.SetActive(false);
    //     // RayRight.SetActive(false);
    //     // ControlLeftControl.SetActive(true);
    //     // ControlRightControl.SetActive(true);
    //     // gameObject.GetComponent<VideoPlayer>().loopPointReached += OnVideoEnd;
    //     // videoPlayer.clip = videoClips[currentClipIndex];
    //     // videoPlayer.loopPointReached += OnVideoEnd;
    //     // videoPlayer.Play();
    // }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayAudioSequentially();
    }

    void PlayAudioSequentially()
    {
        // Reproduce el primer audio
        audioSource.clip = audioClip1;
        audioSource.Play();

        // Espera a que termine el primer audio y luego reproduce el segundo audio
        // StartCoroutine(WaitForAudioClip(audioClip1.length));
    }

    IEnumerator WaitForAudioClip(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Reproduce el segundo audio
        audioSource.clip = audioClip2;
        audioSource.Play();
    }
    // void OnVideoEnd(VideoPlayer vp)
    // {
    //     // Aquí puedes realizar acciones cuando el video termine, como cargar una nueva escena.
    //     Debug.Log("El video ha terminado!");
    //     ControlLeftControl.SetActive(false);
    //     ControlRightControl.SetActive(false);
    //     ControlLeftHand.SetActive(true);
    //     ControlRightHand.SetActive(true);
    //     RayLeft.SetActive(true);
    //     RayRight.SetActive(true);
    //     currentClipIndex++;

    //     // Verificar si hay más videoclips en el array
    //     if (currentClipIndex < videoClips.Length)
    //     {
    //         if (currentClipIndex == 1)
    //         {
    //             ControlLeftHand.SetActive(false);
    //             ControlRightHand.SetActive(false);
    //             RayLeft.SetActive(false);
    //             RayRight.SetActive(false);
    //             ControlLeftControl.SetActive(true);
    //             ControlRightControl.SetActive(true);
    //         }
    //         // Cambiar al siguiente videoclip y reproducirlo
    //         videoPlayer.clip = videoClips[currentClipIndex];
    //         videoPlayer.Play();
    //     }
    //     else
    //     {
    //         // Todos los videoclips se han reproducido
    //         Debug.Log("Todos los videoclips han terminado.");
    //         Settings.Instance.EnableVideos = true;
    //         gameObject.SetActive(false);
    //         // Aquí puedes realizar acciones adicionales si lo deseas
    //     }
    // }

    // Update is called once per frame
    void Update()
    {





    }
}
