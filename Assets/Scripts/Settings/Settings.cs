using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.UI;
using System;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

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
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        xrOrigin.GetComponent<DynamicMoveProvider>().enabled = false;
        buttonTutorialContinuar.onClick.AddListener(OnButtonClick);
    }

    void Start()
    {


    }


    void Update()
    {
        xrOrigin.GetComponent<DynamicMoveProvider>().enabled = enableMoveXrOrigin;
        if (countEnable == false && enableMoveXrOrigin)
        {
            OnButtonClick();
        }
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
