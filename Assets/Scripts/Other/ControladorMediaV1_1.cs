using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControladorMediaV1_1 : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator[] anim;
    public GameObject XRControllerLeft;

    [Space(20)]
    public Material BumperButtonXrController;
    public Material TriggerButtonXrController;
    public Material ControlBaseXrController;
    public Material ControlTopXRController;
    public Material TopInputControlXrController;

    [Space(20)]
    public GameObject[] MapPins;
    public Material DefaultMapPinMaterial;
    public Material HighlitedMapPinMaterial;

    [Space(20)]
    public GameObject[] Tools;
    public Material DefaultToolMaterial;
    public Material HighlitedToolMaterial;

    [Space(20)]
    public AudioSource audioSource;
    public AudioClip audioLobby_ESP, audioLobby_ENG;
    public int[] timeStamps;

    [Space(20)]
    public int currentClipIndex = 0;
    [Space(5)]
    public AudioClip[] audioClips; // Asigna los clips de audio en el inspector de Unity
    public AudioClip[] audioClipsENG; // Asigna los clips de audio en el inspector de Unity




    private bool isAudioFinished = false;
    public Material v;
    public Material vv;

    public GameObject SphereCascoSocket;
    public float amplitude = 1f;  // Amplitud del movimiento
    public float frequency = 1.0f;  // Frecuencia del movimiento

    public float phase = -0.9663037f;
    private bool actionDone = false;
    private bool switchEventsAudio = false;
    private bool enableEffectControl = false;
    private bool enableEffectControl2 = false;
    private bool enableEffectControl3 = false;
    private bool enableEffectControl4 = false;

    private float timer = 0;
    private bool isAudioSourceBusy = false;
    private bool audioWasPlaying = false;

    //To count the objects the player grabbed in the tutorial after the audio told them to grab things
    public static int grabCount = 0;
    public static int mapInteractionCount = 0;

    void Start()
    {
        // if (audioSourceObject == null)
        // {
        //     audioSourceObject = GetComponent<AudioSource>();
        // }
        //foreach (var item in anim)
        //{
        //    item.GetComponent<Animator>();

        //}

        Invoke("enableAudio", 2f);

        // ChangeHighlight(MapPins, DefaultMapPinMaterial);
        // ChangeHighlight(Tools, DefaultToolMaterial);

        audioSource.Stop();

        //audioSource.clip = audioClips[0];
        //audioSource.PlayDelayed(3); 

        //PlayNextClip();


        //audioSource.PlayDelayed();

        XRControllerLeft.SetActive(false);

    }
    void enableAudio()
    {
        switchEventsAudio = true;
    }
    void greeting()
    {
        Debug.Log("hi");
    }
    void PlayCurrentClip(float delay)
    {
        if (audioSource.isPlaying) return;
        isAudioSourceBusy = true;


        // Si hemos llegado al final de la lista de clips, detenerse
        if (Settings.Instance.language == Language.Espanol)
        {
            if (currentClipIndex >= audioClips.Length)
            {
                //Debug.Log("Todos los clips de audio han terminado");
                return;
            }
        }
        else if (Settings.Instance.language == Language.English)
        {
            if (currentClipIndex >= audioClipsENG.Length)
            {
                //Debug.Log("Todos los clips de audio han terminado");
                return;
            }
        }

        if (currentClipIndex == 1)
        {

            //foreach (var item in anim)
            //{

            //    item.SetTrigger("ampliacion de los menus");
            //}
        }

        // Establecer el siguiente clip para el AudioSource y reproducirlo
        if (Settings.Instance.language == Language.English)
        {
            audioSource.clip = audioClipsENG[currentClipIndex];
            audioSource.PlayDelayed(delay);
        }
        else if (Settings.Instance.language == Language.Espanol)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.PlayDelayed(delay);
        }
        //Invoke("IncrementClipIndex", audioClips[currentClipIndex].length);

        // Avanzar al siguiente clip para la próxima vez

        //Debug.Log(currentClipIndex);
    }

    void IncrementClipIndex()
    {
        currentClipIndex++;
    }

    public void IncrementGrabCount()
    {
        if (currentClipIndex == 3)
        {
            grabCount += 1;
        }
    }

    public void IncrementMapInteractionCount()
    {
        if (currentClipIndex == 4)
        {
            mapInteractionCount += 1;
        }
    }

    void Update()
    {
        if (audioWasPlaying != audioSource.isPlaying) //there was a change in audioSource.isPlaying
        {
            //Debug.Log($"Was={audioWasPlaying}, is={audioSource.isPlaying}!");
            if (!audioSource.isPlaying) //Falling edge
            {
                currentClipIndex++;
            }
            audioWasPlaying = audioSource.isPlaying;
        }

        // condicion de colocacion de casco y chaleco de seguridad
        if (Settings.Instance.checkBaseCasco && Settings.Instance.checkBaseChalecoDeSeguridad)// 6 es el layer casco no cambiar orden
        {
            switchEventsAudio = true;
            //Debug.Log("Trigeo");
        }
        if (Settings.Instance.checkTools)
        {
            switchEventsAudio = true;
        }

        if (currentClipIndex == 1 || currentClipIndex == 2)
        {
            switchEventsAudio = true;
        }
        if (currentClipIndex == 1)
        {
            switchEventsAudio = true;
        }

        // añadir las otras condiciones
        if (!audioSource.isPlaying && switchEventsAudio)
        {
            //PlayNextClip();
            // Invoke("PlayNextClip", 1f);
            switchEventsAudio = false;


            //Debug.Log("Entre");

        }


        if (Settings.Instance.language == Language.Espanol)
        {
            //Pasar al siguiente audio, no hay que hacer ninguna accion
            if ((currentClipIndex == 0 || currentClipIndex == 1) && !audioSource.isPlaying)
            {
                PlayCurrentClip(0);
            }

            //Indicar que podemos agarrar cosas
            if (currentClipIndex == 2 && !audioSource.isPlaying)
            {
                PlayCurrentClip(1);
                // Invoke("HighlightTools", 9.5f);
                Invoke("HighlightTrigger", 14f);
                Invoke("UnhighlightTrigger", 18f);

            }

            //Indicar el trigger cuando indicamos el mapa

            if (currentClipIndex == 3 && grabCount >= 1 && !audioSource.isPlaying)
            {
                PlayCurrentClip(2.5f);
                // Invoke("HighlightMapPins", 6f);

            }
            if (currentClipIndex == 4 && mapInteractionCount >= 3)
            {
                PlayCurrentClip(3f);
                XRControllerLeft.SetActive(false);

            }


        }

        else if (Settings.Instance.language == Language.English)
        {
            #region Cosas de RU
            if (audioWasPlaying != audioSource.isPlaying) //there was a change in audioSource.isPlaying
            {
                //Debug.Log($"Was={audioWasPlaying}, is={audioSource.isPlaying}!");
                if (!audioSource.isPlaying) //Falling edge
                {
                    currentClipIndex++;
                }
                audioWasPlaying = audioSource.isPlaying;
            }

            // condicion de colocacion de casco y chaleco de seguridad
            if (Settings.Instance.checkBaseCasco && Settings.Instance.checkBaseChalecoDeSeguridad)// 6 es el layer casco no cambiar orden
            {
                switchEventsAudio = true;
                //Debug.Log("Trigeo");
            }
            if (Settings.Instance.checkTools)
            {
                switchEventsAudio = true;
            }

            if (currentClipIndex == 1 || currentClipIndex == 2)
            {
                switchEventsAudio = true;
            }
            if (currentClipIndex == 1)
            {
                switchEventsAudio = true;
            }

            // añadir las otras condiciones
            if (!audioSource.isPlaying && switchEventsAudio)
            {
                //PlayNextClip();
                // Invoke("PlayNextClip", 1f);
                switchEventsAudio = false;


                //Debug.Log("Entre");

            }
            #endregion

            if ((currentClipIndex == 0 || currentClipIndex == 1) && !audioSource.isPlaying)
            {
                PlayCurrentClip(0);
            }

            //Indicar que podemos agarrar cosas
            if (currentClipIndex == 2 && !audioSource.isPlaying)
            {
                PlayCurrentClip(1);
                // Invoke("HighlightTools", 9.5f);
                Invoke("HighlightTrigger", 14f);
                Invoke("UnhighlightTrigger", 18f);

            }

            //Indicar el trigger cuando indicamos el mapa

            if (currentClipIndex == 3 && grabCount >= 1 && !audioSource.isPlaying)
            {
                PlayCurrentClip(2.5f);
                // Invoke("HighlightMapPins", 6f);

            }
            if (currentClipIndex == 4 && mapInteractionCount >= 3)
            {
                PlayCurrentClip(3f);
                XRControllerLeft.SetActive(false);

            }
        }

    }

    public void HighlightTrigger()
    {
        Debug.Log("Highlightning Trigger!");

        Color blanco = new Color(1f, 1f, 1f, 0);

        //XRControllerLeft.SetActive(true);
        //BumperButtonXrController.SetColor("_BaseColor", blanco);        
        //if (Settings.Instance.SalidaCheck)
        //{
        //    XRControllerLeft.SetActive(false);

        //}
        //Color newColor = new Color(47f / 255f, 140f / 255f, 231f / 255f, 0);
        //TriggerButtonXrController.SetColor("_BaseColor", newColor);

        XRControllerLeft.SetActive(true);
    }

    public void UnhighlightTrigger()
    {
        XRControllerLeft.SetActive(false);
    }

    public void HighlightMapPins()
    {
        foreach (var pin in MapPins)
        {
            MeshRenderer rend = pin.GetComponent<MeshRenderer>();
            rend.SetMaterials(new List<Material>()
            {
                rend.materials[0],
                HighlitedMapPinMaterial
            });

        }
    }

    public void UnhighlightMapPins()
    {
        foreach (var pin in MapPins)
        {
            MeshRenderer rend = pin.GetComponent<MeshRenderer>();
            rend.SetMaterials(new List<Material>()
            {
                rend.materials[0],
                DefaultMapPinMaterial
            });
        }
    }

    public void HighlightTools()
    {
        foreach (var pin in Tools)
        {
            MeshRenderer rend = pin.GetComponent<MeshRenderer>();
            rend.SetMaterials(new List<Material>()
            {
                rend.materials[0],
                HighlitedToolMaterial
            });

        }
    }

    public void UnhighlightTools()
    {
        foreach (var pin in MapPins)
        {
            MeshRenderer rend = pin.GetComponent<MeshRenderer>();
            rend.SetMaterials(new List<Material>()
            {
                rend.materials[0],
                DefaultToolMaterial
            });
        }
    }

    public void ChangeHighlight(GameObject[] objArray, Material material)
    {
        foreach (var pin in objArray)
        {
            MeshRenderer rend = pin.GetComponent<MeshRenderer>();
            rend.SetMaterials(new List<Material>()
            {
                rend.materials[0],
                material
            });
        }
    }

    public void delay(float seconds)
    {

        while (timer < seconds / Time.deltaTime)
        {
            timer += Time.deltaTime;
        }
    }

    IEnumerator IncrementCurrentIndex()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);

        Debug.Log("Audio Finished");
        isAudioSourceBusy = false;
        currentClipIndex++;
    }
}
