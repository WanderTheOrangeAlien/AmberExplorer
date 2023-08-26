using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Canvas_TutorialSelector : MonoBehaviour
{
    public PanelSet_t[] panelSets;
    public GameObject[] selectorButtons;
    public Button buttonBack;
    private bool enableToWalk = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        buttonBack.gameObject.SetActive(false);

        Debug.Log("Setting up");
        Debug.Log("Language:" + Settings.Instance.language.ToString());
        Debug.Log(panelSets.Length + " " + selectorButtons.Length);
        if (panelSets.Length != selectorButtons.Length) Debug.LogError("Panels and buttons array must be the same size!");

        buttonBack.gameObject.SetActive(true);
        buttonBack.onClick.AddListener(() =>
        {
            DisableAllPanelSets();
            buttonBack.gameObject.SetActive(false);

            // Settings.Instance.xrOrigin.GetComponent<DynamicMoveProvider>().enabled = enableToWalk;
            Settings.Instance.enableMoveXrOrigin = enableToWalk;

        });
        buttonBack.gameObject.SetActive(false);


        //Map each button to a panelSet
        for (int i = 0; i < selectorButtons.Length; i++)
        {
            //Debug.Log("Adding onClick to " + i);


            int panelIndex_ = i; //For some reason, lambda functions pass the i variable of a for loop as a reference

            if (selectorButtons[i].GetComponent<Button>() != null)
            {
                selectorButtons[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    // play around to see who to enable move.
                    // Settings.Instance.xrOrigin.GetComponent<DynamicMoveProvider>().enabled = true;

                    ChangePanelSet(panelIndex_);

                });
            }
            else //Is an object outside the canvas, use the XRInteractable SelectEntered event
            {
                Debug.Log($"{selectorButtons[i].name} did not have a button component");
                //DEBUG: NON VR FOR TESTING
                selectorButtons[i].GetComponent<OnRaycastHitEvent>().OnRaycastHit += () =>
                {
                    Debug.Log($"Changing to panel {panelIndex_} ({selectorButtons[panelIndex_].name})");
                    ChangePanelSet(panelIndex_);
                };


                selectorButtons[i].GetComponent<XRSimpleInteractable>().selectEntered.AddListener((SelectEnterEventArgs) =>
                {
                    ChangePanelSet(panelIndex_);
                });


            }

        }

        //SetUp the backButton



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangePanelSet(int panelID)
    {
        DisableAllPanelSets();

        Debug.Log($"{gameObject.name}: Changing to panelSet {panelID}. Lang={Settings.Instance.language}");



        if (Settings.Instance.language == Language.English)
        {
            panelSets[panelID].EnglishPanelSet.SetActive(true);

        }
        else if (Settings.Instance.language == Language.Espanol)
        {
            panelSets[panelID].SpanishPanelSet.SetActive(true);
        }
        buttonBack.gameObject.SetActive(true);
        activeTutorials(panelID);

    }
    public void activeTutorials(int panelID)
    {
        Debug.Log(panelID + "huuuuu");

        if (panelID == selectorButtons.Length - 1 && selectorButtons[panelID].GetComponent<Button>().interactable)
        {
            // Settings.Instance.xrOrigin.GetComponent<DynamicMoveProvider>().enabled = true;
            enableToWalk = true;
            // Settings.Instance.enableMoveXrOrigin = true;
        }
        if (panelID < selectorButtons.Length)
        {
            selectorButtons[panelID + 1].GetComponent<Button>().interactable = true;
        }
        Debug.Log(panelID + "hi");
    }
    public void DisableAllPanelSets()
    {
        for (int i = 0; i < panelSets.Length; i++)
        {
            if (Settings.Instance.language == Language.English)
            {
                panelSets[i].EnglishPanelSet.SetActive(false);

            }
            else if (Settings.Instance.language == Language.Espanol)
            {
                panelSets[i].SpanishPanelSet.SetActive(false);
            }

        }
    }

}
[System.Serializable]
public struct PanelSet_t
{
    public GameObject SpanishPanelSet;
    public GameObject EnglishPanelSet;
}
