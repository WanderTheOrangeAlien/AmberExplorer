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
    public int panelCount;

    //Temp
    public GameObject[] panels;
    public Button[] btnsRight;
    public Button[] btnsLeft;

    private Regex panelRegex,btnLeftRegex,btnRightRegex;
    private int panelIndex = 0;


    void Start()
    {
        panelRegex = new Regex(panelNameConvention);
        btnLeftRegex = new Regex(buttonLeftNameConvention);
        btnRightRegex = new Regex(buttonRightNameConvention);

        Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
        panels = new GameObject[panelCount];
        btnsRight = new Button[panelCount];
        btnsLeft = new Button[panelCount];

        gameObject.SetActive(true);

        for (int i = 0; i < childrenTransforms.Length; i++)
        {
 
            //GetComponentsInChildren also returns the childern of children
            if (panelRegex.IsMatch(childrenTransforms[i].gameObject.name))
            {
                panels[panelIndex] = childrenTransforms[i].gameObject;
                panelIndex++;
            }

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

            
        }

        //Activate default panel
        ChangePanel(0);
        panelIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePanel(int panelID)
    {
        for (int i = 0; i < panelCount; i++)
        {
            panels[i].SetActive(false);
        }

        Debug.Log("Changin to panel" + panelID);

        panels[panelID].SetActive(true);
    }
}
