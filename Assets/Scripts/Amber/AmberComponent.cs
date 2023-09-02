using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class AmberComponent : MonoBehaviour
{
    public delegate void AmberCollected(string itemId);
    public static event AmberCollected OnAmberCollected;
    //public AmberScriptableObject amberData;
    public bool useCustomMesh = false, useCustomMaterial = false;


    public string collectionAreaTag = "Score";

    [Space(15)]
    public AudioClip collectedSound;
    public AudioClip disappearSound;
    public AudioClip collectedVoiceOver_ESP;
    public AudioClip collectedVoiceOver_ENG;

    [Space(20)]
    public string itemId;
    public Material amberMaterial;

    [Space(20)]
    public GameObject amber;

    private AudioClip voiceOver;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private XRGrabInteractable xrGrabbable;
    private AudioSource audioSource;

    private AudioClip collectedVoiceOver;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        xrGrabbable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        //meshFilter.mesh = amberData.model;

        if (useCustomMaterial)
        {
            amber.GetComponent<MeshRenderer>().material = amberMaterial;
        }

        //Call the Grab event
        xrGrabbable.selectEntered.AddListener((ActivateEventArgs) =>
        {
            CollectedMethod();
        });

        //Language dependent selection
        if (Settings.Instance.language == Language.English)
        {
            collectedVoiceOver = collectedVoiceOver_ENG;

        }
        else if (Settings.Instance.language == Language.Espanol)
        {
            collectedVoiceOver = collectedVoiceOver_ESP;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectionAreaTag)
        {
            //OnAmberCollected(amberData);
            Debug.Log($"{gameObject.name}: Detected collection area");

        }
    }

    public void CollectedMethod()
    {
        audioSource.clip = collectedSound;
        audioSource.Play();
        Debug.Log("Wait time=" + collectedSound.length);
        Invoke("PlayVoiceOver", collectedSound.length - 1.5f);

        Invoke("SendCollected", collectedSound.length + collectedVoiceOver.length);
    }

    public void SendCollected()
    {
        //Event
        OnAmberCollected(itemId);
        audioSource.clip = collectedSound;
        audioSource.Play();
        gameObject.SetActive(false);
    }

    public void PlayVoiceOver()
    {
        audioSource.clip = collectedVoiceOver;
        audioSource.Play();
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
