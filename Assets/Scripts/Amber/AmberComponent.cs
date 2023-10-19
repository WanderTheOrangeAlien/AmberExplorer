using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class AmberComponent : MonoBehaviour
{
    public delegate void AmberCollected(AmberScriptableObject ambarData);
    public static event AmberCollected OnAmberCollected;
    //public AmberScriptableObject amberData;
    public bool useCustomMesh = false, useCustomMaterial = false;

    public AmberScriptableObject amberData;

    [Space(15)]
    public AudioClip collectedSound;
    public AudioClip disappearSound;
    public AudioClip collectedVoiceOver_ESP;
    public AudioClip collectedVoiceOver_ENG;

    [Space(20)]
    public GameObject targetModel;
    public bool isCollected = false;

    private AudioClip voiceOver;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private XRGrabInteractable xrGrabbable;
    private AudioSource audioSource;

    private AudioClip collectedVoiceOver;
    private VoiceOverPlayer voiceOverPlayer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        xrGrabbable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        voiceOverPlayer = FindObjectOfType<VoiceOverPlayer>();

        //meshFilter.mesh = amberData.model;

        if (useCustomMaterial)
        {
            targetModel.GetComponent<MeshRenderer>().material = amberData.ambarMaterial;
        }

        //Call the Grab event
        xrGrabbable.selectEntered.AddListener((ActivateEventArgs) =>
        {
            if (!isCollected)
            {
                CollectedMethod();
                isCollected = true;
            }
            
        });

        //Language dependent selection
        if (GlobalSettings.Instance.language == Language.English)
        {
            collectedVoiceOver = collectedVoiceOver_ENG;

        }
        else if (GlobalSettings.Instance.language == Language.Espanol)
        {
            collectedVoiceOver = collectedVoiceOver_ESP;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectedMethod()
    {
        audioSource.pitch = 1;

        audioSource.clip = collectedSound;
        audioSource.Play();
        Debug.Log("Wait time=" + collectedSound.length);
        //Invoke methods are used for delay between audio clips

        Invoke("PlayVoiceOver", collectedSound.length - 1.5f);

        Invoke("SendCollected", collectedSound.length);
    }

    public void SendCollected()
    {
        //Event
        if(OnAmberCollected == null)
        {
            Debug.LogError("OnAmberCollected was null!!");
        }

        OnAmberCollected(amberData);
        audioSource.clip = collectedSound;
        audioSource.Play();
        gameObject.SetActive(false);
    }

    public void PlayVoiceOver()
    {
        voiceOverPlayer.playClip(collectedVoiceOver);
    }
}

/// <summary>
/// Types of Amber
/// </summary>
public enum AmberType
{
    Miel,
    Naranja,
    Rojo,
    Azul
}
