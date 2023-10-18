using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_TutorialHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public string panelNameConvention;
    public string buttonRightNameConvention;
    public string buttonLeftNameConvention;
    public string buttonBackNameConvention;
    public int panelCount;

    //Temp
    public GameObject[] panels;
    public Button[] btnsRight;
    public Button[] btnsLeft;
    public GameObject panelParent;
    public Button btnBack;
    [Space(10)]
    public bool isHiddenByDefault;

    private Regex panelRegex,btnLeftRegex,btnRightRegex,btnBackRegex;
    private int panelIndex = 0;

    private bool isArrayInitialized = false;


    void Start()
    {
        panelRegex = new Regex(panelNameConvention);
        btnLeftRegex = new Regex(buttonLeftNameConvention);
        btnRightRegex = new Regex(buttonRightNameConvention);
        btnBackRegex = new Regex(buttonBackNameConvention);

        Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
        panels = new GameObject[panelCount];
        btnsRight = new Button[panelCount];
        btnsLeft = new Button[panelCount];

        gameObject.SetActive(true);

        Debug.Log($"[{gameObject.name}] Regex Match: {panelRegex.IsMatch("Panel_UI_fgbfg")}");

        for (int i = 0; i < childrenTransforms.Length; i++)
        {
 
            //GetComponentsInChildren also returns the childern of children

            //Pannel assigment
            if (panelRegex.IsMatch(childrenTransforms[i].gameObject.name))
            {
                Debug.Log($"Added {childrenTransforms[i].gameObject.name} to panel array");
                panels[panelIndex] = childrenTransforms[i].gameObject;
                panelIndex++;
            }

            //Button right assignment
            if (btnRightRegex.IsMatch(childrenTransforms[i].gameObject.name))
            {
                //panelindex - 1 because it was incremented when the panel was added to the array
                btnsRight[panelIndex - 1] = childrenTransforms[i].gameObject.GetComponent<Button>();

                if (btnsRight[panelIndex - 1] != null)
                {
                    Debug.Log($"[TutorialHandler]: Added ChangePanel({panelIndex}) to {childrenTransforms[i].gameObject.name}[{panelIndex - 1}]");
                    int _panelIndexR = panelIndex;
                    btnsRight[panelIndex - 1].onClick.AddListener(() =>
                    {                        
                        ChangePanel(_panelIndexR);
                    });
                }
            }

            //Button left assignment
            if (btnLeftRegex.IsMatch(childrenTransforms[i].gameObject.name))
            {

                btnsLeft[panelIndex - 1] = childrenTransforms[i].gameObject.GetComponent<Button>();

                //OnClick event assigment
                if (btnsLeft[panelIndex - 1] != null)//Check if there is a left button in the current panel
                {
                    Debug.Log($"[TutorialHandler]: Added ChangePanel({panelIndex-2}) to {childrenTransforms[i].gameObject.name}[{panelIndex-1}]");
                    int _panelIndexL = panelIndex;
                    btnsLeft[panelIndex - 1].onClick.AddListener(() =>
                    {
                        

                        ChangePanel(_panelIndexL -2); //Change to the previous panel
                    });
                }
                
            }

            //Button back assignment
            if (btnBackRegex.IsMatch(childrenTransforms[i].gameObject.name))
            {
                btnBack = childrenTransforms[i].gameObject.GetComponent<Button>();
                btnBack.onClick.AddListener(() =>
                {
                    ChangeToParent();
                });
            }



            if (panels[0] == null)
            {
                Debug.LogError("No panels found! Remember all children must be active during Start in order to be added to the array!");
            }

            gameObject.SetActive(!isHiddenByDefault);

            
        }

        

        //Activate default panel
        ChangePanel(0);
        panelIndex = 0;
        isArrayInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePanel(int panelID)
    {
        

        for (int i = 0; i < panelCount; i++)
        {
            if (panels[i] == null) return;
            panels[i].SetActive(false);
        }

        Debug.Log("Changin to panel" + panelID);

        panels[panelID].SetActive(true);
    }

    public void ChangeToParent()
    {
        for (int i = 0; i < panelCount; i++)
        {
            panels[i].SetActive(false);
        }

        panelParent.SetActive(true);
        gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        if (isArrayInitialized)
        {
            ChangePanel(0);
        }
        btnBack.gameObject.SetActive(true);
    }
}
