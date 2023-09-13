using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.UI;
using System;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Settings : MonoBehaviour
{
    public static Settings Instance { get; private set; }
    public Language language = Language.Espanol;
    public GameObject xrOrigin;
    public GameObject Chaleco;
    public GameObject Martillo;
    public GameObject ChinchetaLaCumbre;
    public GameObject ChinchetaElValle;
    public GameObject ChinchetaSabanaDeLaMar;
    public GameObject SecurityHat;
    public GameObject LinternaBlanca;
    public GameObject LinternaNegra;
    public GameObject Cincel;
    public GameObject Martillo1;
    public GameObject Martillo2;
    public GameObject Mazo;
    public bool enableMoveXrOrigin;
    public Button buttonTutorialContinuar;
    private bool countEnable;
    public bool EnableVideos;
    public bool checkBaseCasco;
    public bool checkBaseChalecoDeSeguridad;
    public bool checkTools;
    public bool checkKeyCasco;
    public bool checkKeyChaleco;

    public bool EntradaCheck = false;
    public bool SalidaCheck = false;
    public bool GlobalAudio = false;

    public Material v1;
    public Material v2;
    public Material[] ControlMaterial;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        v1.SetFloat("_MeshTransparent", -0.8517735f);
        v2.SetFloat("_MeshTransparent", -0.8517735f);
        // If there is an instance, and it's not me, delete myself.

        foreach (var item in ControlMaterial)
        {

            item.SetFloat("_MeshTransparent", -1.87f);
        }



        if (xrOrigin != null)
            xrOrigin.GetComponent<DynamicMoveProvider>().enabled = false;

        if (buttonTutorialContinuar != null)
            buttonTutorialContinuar.onClick.AddListener(OnButtonClick);
    }

    void Start()
    {


    }


    void Update()
    {
        if (xrOrigin != null)
        {
            xrOrigin.GetComponent<DynamicMoveProvider>().enabled = enableMoveXrOrigin;
            if (countEnable == false && enableMoveXrOrigin)
            {
                OnButtonClick();
            }
        }


        // TextMeshProUGUI textComponent1 = TutorialesText.GetComponent<TextMeshProUGUI>();
        // TextMeshProUGUI textComponent2 = ControlesText.GetComponent<TextMeshProUGUI>();
        // TextMeshProUGUI textComponent3 = HerramientasText.GetComponent<TextMeshProUGUI>();
        // TextMeshProUGUI textComponent4 = SeguridadText.GetComponent<TextMeshProUGUI>();

        // if (Instance.language == Language.Espanol)
        // {

        //     if (textComponent1 != null)
        //     {
        //         textComponent1.text = "Tutoriales";
        //     }
        //     if (textComponent2 != null)
        //     {
        //         textComponent2.text = "Controles";
        //     }
        //     if (textComponent3 != null)
        //     {
        //         textComponent3.text = "Herramientas";
        //     }
        //     if (textComponent4 != null)
        //     {
        //         textComponent4.text = "Seguridad";
        //     }
        // }
        // else
        // {

        //     if (textComponent1 != null)
        //     {
        //         textComponent1.text = "Tutorials";
        //     }
        //     if (textComponent2 != null)
        //     {
        //         textComponent2.text = "Controls";
        //     }
        //     if (textComponent3 != null)
        //     {
        //         textComponent3.text = "Tools";
        //     }
        //     if (textComponent4 != null)
        //     {
        //         textComponent4.text = "Security";
        //     }
        // }

        // just in case want to modyfy directly the layermask of the raycast interacto.\
        // int layerMask = 1 << LayerMask.NameToLayer("Default");

        // rayIndicatorLeftHand.GetComponent<XRRayInteractor>().interactionLayers = layerMask;
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    public void OnButtonClick()
    {
        xrOrigin.GetComponent<DynamicMoveProvider>().enabled = true;
        enableMoveXrOrigin = true;
        SetLayerRecursively(Martillo, 0);
        // Martillo.layer = 0;
        SetLayerRecursively(Chaleco, 0);
        SetLayerRecursively(ChinchetaLaCumbre, 0);
        SetLayerRecursively(ChinchetaElValle, 0);
        SetLayerRecursively(ChinchetaSabanaDeLaMar, 0);
        SetLayerRecursively(SecurityHat, 0);
        SetLayerRecursively(LinternaBlanca, 0);
        SetLayerRecursively(LinternaNegra, 0);
        SetLayerRecursively(Cincel, 0);
        SetLayerRecursively(Martillo1, 0);
        SetLayerRecursively(Martillo2, 0);
        SetLayerRecursively(Mazo, 0);

        countEnable = true;

    }
}

public enum Language
{
    Espanol,
    English
}
