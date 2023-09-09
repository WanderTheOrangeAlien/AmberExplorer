using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControladorMedia : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator[] anim;
    public GameObject XRControllerLeft;
    public Material BumperButtonXrController;
    public Material TriggerButtonXrController;
    public Material ControlBaseXrController;
    public Material ControlTopXRController;
    public Material TopInputControlXrController;

    public AudioSource audioSource;
    public AudioClip[] audioClips; // Asigna los clips de audio en el inspector de Unity
    public AudioClip[] audioClipsENG; // Asigna los clips de audio en el inspector de Unity
    private int currentClipIndex = 0;
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
    void Start()
    {
        // if (audioSourceObject == null)
        // {
        //     audioSourceObject = GetComponent<AudioSource>();
        // }
        foreach (var item in anim)
        {
            item.GetComponent<Animator>();

        }

        Invoke("enableAudio", 2f);

    }
    void enableAudio()
    {
        switchEventsAudio = true;
    }
    void greeting()
    {
        Debug.Log("hi");
    }
    void PlayNextClip()
    {
        // Si hemos llegado al final de la lista de clips, detenerse
        if (Settings.Instance.language == Language.English)
        {
            if (currentClipIndex >= audioClips.Length)
            {
                Debug.Log("Todos los clips de audio han terminado");
                return;
            }
        }
        else if (Settings.Instance.language == Language.Espanol)
        {
            if (currentClipIndex >= audioClipsENG.Length)
            {
                Debug.Log("Todos los clips de audio han terminado");
                return;
            }
        }
        if (currentClipIndex == 1)
        {

            foreach (var item in anim)
            {

                item.SetTrigger("ampliacion de los menus");
            }
        }
        // Establecer el siguiente clip para el AudioSource y reproducirlo
        if (Settings.Instance.language == Language.English)
        {
            audioSource.clip = audioClipsENG[currentClipIndex];
            audioSource.Play();
        }
        else if (Settings.Instance.language == Language.Espanol)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
        }

        // Avanzar al siguiente clip para la próxima vez
        currentClipIndex++;
        Debug.Log(currentClipIndex);
    }
    // void PlayAudio()
    // {
    //     if (audioSourceObject != null)
    //     {

    //         audioSourceObject.clip = omitirTutorial;
    //         audioSourceObject.Play();

    //     }
    // }

    void Update()
    {
        // condicion de colocacion de casco y chaleco de seguridad
        if (Settings.Instance.checkBaseCasco && Settings.Instance.checkBaseChalecoDeSeguridad)// 6 es el layer casco no cambiar orden
        {
            switchEventsAudio = true;
            Debug.Log("Trigeo");
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
            PlayNextClip();
            // Invoke("PlayNextClip", 1f);
            switchEventsAudio = false;


            Debug.Log("Entre");

        }

        // efecto de mesh
        // if (audioSourceObject.time >= 4 && !actionDone)
        // {
        //     // Haz algo aquí
        //     Debug.Log("Hemos llegado al segundo específico: " + 3);

        //     // Marca la acción como realizada para que no se repita
        //     float time2 = Time.time;

        //     float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
        //     float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
        //     float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

        //     // Calcula el valor de la función sinusoidal
        //     float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

        //     // Rango deseado para la función lineal
        //     float minLinearValue = -1.87f;
        //     float maxLinearValue = 1.87f;

        //     // Convierte el valor sinusoidal al rango lineal
        //     float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 0.5f) / 2);

        //     Debug.Log(linearValue);
        //     Debug.Log(time2);

        //     v.SetFloat("_MeshTransparent", linearValue);
        //     vv.SetFloat("_MeshTransparent", linearValue);
        //     if (audioSourceObject.time >= 9 && Time.time >= 10)
        //     {

        //         Debug.Log("Hemos llegado al segundo específico: " + 9);

        //         actionDone = true;

        //     }
        // }

        // if (!audioSourceObject.isPlaying)
        // {
        //     Debug.Log("el audio termino");
        //     // QuadVideo.SetActive(true);
        // }
        if (Settings.Instance.language == Language.Espanol)
        {

            if (currentClipIndex == 2 && audioSource.time <= 8)
            {
                Color blanco = new Color(1f, 1f, 1f, 0);

                BumperButtonXrController.SetColor("_BaseColor", blanco);
                XRControllerLeft.SetActive(true);
                if (Settings.Instance.SalidaCheck)
                {
                    XRControllerLeft.SetActive(false);

                }
                Color newColor = new Color(47f / 255f, 140f / 255f, 231f / 255f, 0);
                TriggerButtonXrController.SetColor("_BaseColor", newColor);

                // Para el proximo entregable
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = 2.5f;
                // float maxLinearValue = -2.5f;
                // // Color c = new Color(47f, 140f, 231f, 0f);//trigger azul.
                // Color newColor = new Color(47f / 255f, 140f / 255f, 231f / 255f, 0);

                // TriggerButtonXrController.SetColor("_BaseColor", newColor);
                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

                // if (linearValue >= -1.85f && !enableEffectControl)
                // {
                //     // Debug.Log(linearValue);

                //     BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                //     TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);

                // }
                // else
                // {
                //     enableEffectControl = true;
                // }



            }
            if (currentClipIndex == 2 && audioSource.time >= 8)
            {
                XRControllerLeft.SetActive(false);

                // Para el proximo entregable
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = -2.5f;
                // float maxLinearValue = 2.5f;

                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);


                // // Debug.Log(linearValue);

                // BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                // TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);
            }

            if (currentClipIndex == 3 && audioSource.time <= 4)
            {
                Color rojo = new Color(231f / 255f, 76f / 255f, 60f / 255f, 1);
                Color blanco = new Color(1f, 1f, 1f, 0);

                TriggerButtonXrController.SetColor("_BaseColor", blanco);
                BumperButtonXrController.SetColor("_BaseColor", rojo);
                XRControllerLeft.SetActive(true);
                if (Settings.Instance.SalidaCheck || Settings.Instance.GlobalAudio)
                {
                    XRControllerLeft.SetActive(false);

                }
                // Para el proximo entregable
                // Color rojo = new Color(231f / 255f, 76f / 255f, 60f / 255f, 1);
                // Color blanco = new Color(1f, 1f, 1f, 0);

                // TriggerButtonXrController.SetColor("_BaseColor", blanco);
                // BumperButtonXrController.SetColor("_BaseColor", rojo);
                // // Haz algo aquí
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = -2.5f;
                // float maxLinearValue = 2.5f;

                // // TriggerButtonXrController.SetColor("_BaseColor", newColor);
                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

                // if (linearValue >= -1.85f && !enableEffectControl2)
                // {
                //     // Debug.Log(linearValue);

                //     BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                //     TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);

                // }
                // else
                // {
                //     enableEffectControl2 = true;
                // }



            }
            if (currentClipIndex == 3 && audioSource.time >= 5)
            {
                Settings.Instance.GlobalAudio = true;
                XRControllerLeft.SetActive(false);
                // Para el proximo entregable

                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = 2.5f;
                // float maxLinearValue = -2.5f;

                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);
                // if (linearValue > 1.5f)
                // {
                //     enableEffectControl3 = true;
                // }


                // // Debug.Log(linearValue);

                // BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                // TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);

            }

            // Para el proximo entregable
            // if (currentClipIndex == 1 && audioSource.time >= 2 && audioSource.time <= 5)
            // {
            //     Color blanco = new Color(1f, 1f, 1f, 0);

            //     BumperButtonXrController.SetColor("_BaseColor", blanco);
            //     // Haz algo aquí
            //     float time2 = Time.time;

            //     float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
            //     float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
            //     float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

            //     // Calcula el valor de la función sinusoidal
            //     float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

            //     // Rango deseado para la función lineal
            //     float minLinearValue = 1.87f;
            //     float maxLinearValue = -1.87f;

            //     // Convierte el valor sinusoidal al rango lineal
            //     float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

            //     // Debug.Log(linearValue);
            //     // Debug.Log(time2);

            //     v.SetFloat("_MeshTransparent", linearValue);
            //     vv.SetFloat("_MeshTransparent", linearValue);

            //     // if (audioSource.time >= 9 && Time.time >= 10)
            //     // {

            //     //     Debug.Log("Hemos llegado al segundo específico: " + 9);

            //     //     actionDone = true;

            //     // }
            // }
            // if ((currentClipIndex == 1 && audioSource.time >= 9) || !enableEffectControl4)
            // {
            //     // Haz algo aquí
            //     float time2 = Time.time;

            //     float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
            //     float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
            //     float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

            //     // Calcula el valor de la función sinusoidal
            //     float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

            //     // Rango deseado para la función lineal
            //     float minLinearValue = -1.87f;
            //     float maxLinearValue = 1.87f;

            //     // Convierte el valor sinusoidal al rango lineal
            //     float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

            //     // Debug.Log(linearValue);
            //     // Debug.Log(time2);

            //     v.SetFloat("_MeshTransparent", linearValue);
            //     vv.SetFloat("_MeshTransparent", linearValue);

            //     // if (audioSource.time >= 9 && Time.time >= 10)
            //     // {

            //     //     Debug.Log("Hemos llegado al segundo específico: " + 9);

            //     //     actionDone = true;

            //     // }
            //     if (linearValue >= -2f)
            //     {
            //         enableEffectControl4 = true;
            //     }
            // }
        }

        else if (Settings.Instance.language == Language.English)
        {

            if (currentClipIndex == 2 && audioSource.time <= 8)
            {
                XRControllerLeft.SetActive(true);
                if (Settings.Instance.SalidaCheck)
                {
                    XRControllerLeft.SetActive(false);

                }
                Color newColor = new Color(47f / 255f, 140f / 255f, 231f / 255f, 0);
                TriggerButtonXrController.SetColor("_BaseColor", newColor);

                // Haz algo aquí
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = 2.5f;
                // float maxLinearValue = -2.5f;
                // // Color c = new Color(47f, 140f, 231f, 0f);//trigger azul.
                // Color newColor = new Color(47f / 255f, 140f / 255f, 231f / 255f, 0);

                // TriggerButtonXrController.SetColor("_BaseColor", newColor);
                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

                // if (linearValue >= -1.85f && !enableEffectControl)
                // {
                //     // Debug.Log(linearValue);

                //     BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                //     TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);

                // }
                // else
                // {
                //     enableEffectControl = true;
                // }



            }
            if (currentClipIndex == 2 && audioSource.time >= 8)
            {
                XRControllerLeft.SetActive(false);
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = -2.5f;
                // float maxLinearValue = 2.5f;

                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);


                // // Debug.Log(linearValue);

                // BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                // TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);
            }

            if (currentClipIndex == 3 && audioSource.time <= 4)
            {
                Color rojo = new Color(231f / 255f, 76f / 255f, 60f / 255f, 1);
                Color blanco = new Color(1f, 1f, 1f, 0);

                TriggerButtonXrController.SetColor("_BaseColor", blanco);
                BumperButtonXrController.SetColor("_BaseColor", rojo);
                XRControllerLeft.SetActive(true);
                if (Settings.Instance.SalidaCheck || Settings.Instance.GlobalAudio)
                {
                    XRControllerLeft.SetActive(false);

                }
                // Color rojo = new Color(231f / 255f, 76f / 255f, 60f / 255f, 1);
                // Color blanco = new Color(1f, 1f, 1f, 0);

                // TriggerButtonXrController.SetColor("_BaseColor", blanco);
                // BumperButtonXrController.SetColor("_BaseColor", rojo);
                // // Haz algo aquí
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = -2.5f;
                // float maxLinearValue = 2.5f;

                // // TriggerButtonXrController.SetColor("_BaseColor", newColor);
                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

                // if (linearValue >= -1.85f && !enableEffectControl2)
                // {
                //     // Debug.Log(linearValue);

                //     BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                //     ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                //     TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);

                // }
                // else
                // {
                //     enableEffectControl2 = true;
                // }



            }
            if (currentClipIndex == 3 && audioSource.time >= 5)
            {


                Settings.Instance.GlobalAudio = true;
                XRControllerLeft.SetActive(false);
                // float time2 = Time.time;

                // float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
                // float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
                // float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

                // // Calcula el valor de la función sinusoidal
                // float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

                // // Rango deseado para la función lineal
                // float minLinearValue = -2.5f;
                // float maxLinearValue = 2.5f;

                // // Convierte el valor sinusoidal al rango lineal
                // float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);
                // if (linearValue > 1.5f)
                // {
                //     enableEffectControl3 = true;
                // }


                // // Debug.Log(linearValue);

                // BumperButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // TriggerButtonXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlBaseXrController.SetFloat("_MeshTransparent", linearValue);
                // ControlTopXRController.SetFloat("_MeshTransparent", linearValue);
                // TopInputControlXrController.SetFloat("_MeshTransparent", linearValue);

            }


            // if (currentClipIndex == 1 && audioSource.time >= 2 && audioSource.time <= 5)
            // {
            //     Color blanco = new Color(1f, 1f, 1f, 0);

            //     BumperButtonXrController.SetColor("_BaseColor", blanco);
            //     // Haz algo aquí
            //     float time2 = Time.time;

            //     float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
            //     float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
            //     float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

            //     // Calcula el valor de la función sinusoidal
            //     float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

            //     // Rango deseado para la función lineal
            //     float minLinearValue = 1.87f;
            //     float maxLinearValue = -1.87f;

            //     // Convierte el valor sinusoidal al rango lineal
            //     float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

            //     // Debug.Log(linearValue);
            //     // Debug.Log(time2);

            //     v.SetFloat("_MeshTransparent", linearValue);
            //     vv.SetFloat("_MeshTransparent", linearValue);

            //     // if (audioSource.time >= 9 && Time.time >= 10)
            //     // {

            //     //     Debug.Log("Hemos llegado al segundo específico: " + 9);

            //     //     actionDone = true;

            //     // }
            // }
            // if ((currentClipIndex == 1 && audioSource.time >= 8) || !enableEffectControl4)
            // {
            //     // Haz algo aquí
            //     float time2 = Time.time;

            //     float frequency = 1.0f;  // Puedes ajustar la frecuencia según tus necesidades
            //     float amplitude = 1.0f;  // Puedes ajustar la amplitud según tus necesidades
            //     float phase = 0.0f;      // Puedes ajustar la fase según tus necesidades

            //     // Calcula el valor de la función sinusoidal
            //     float sinusoidalValue = Mathf.Sin(time2 * frequency - phase) * amplitude;

            //     // Rango deseado para la función lineal
            //     float minLinearValue = -2.87f;
            //     float maxLinearValue = 1.87f;

            //     // Convierte el valor sinusoidal al rango lineal
            //     float linearValue = Mathf.Lerp(minLinearValue, maxLinearValue, (sinusoidalValue + 1) / 2);

            //     // Debug.Log(linearValue);
            //     // Debug.Log(time2);

            //     v.SetFloat("_MeshTransparent", linearValue);
            //     vv.SetFloat("_MeshTransparent", linearValue);

            //     // if (audioSource.time >= 9 && Time.time >= 10)
            //     // {

            //     //     Debug.Log("Hemos llegado al segundo específico: " + 9);

            //     //     actionDone = true;

            //     // }
            //     if (linearValue >= -2f)
            //     {
            //         enableEffectControl4 = true;
            //     }
            // }
        }

    }

}
