using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartCanvas : MonoBehaviour
{

    public GameObject btn_Start, btn_Credits, btn_Exit;
    [Space(10)]
    public GameObject btn_ESP;
    public GameObject btn_ENG;
    [Space(10)]
    public GameObject panel_LanguageSelection;
    public GameObject panel_StartMenu;
    public GameObject panel_TimeSelection_ESP;
    public GameObject panel_TimeSelection_ENG;
    [Space(10)]
    public Sprite[] sprites_ESP;
    public Sprite[] sprites_ENG;

    public GameObject panel_Credits_ESP;
    public GameObject panel_Credits_ENG;

    // Start is called before the first frame update
    void Start()
    {
        ChangePanel(panel_LanguageSelection);

        btn_ESP.GetComponent<Button>().onClick.AddListener(() =>
        {

            Debug.Log(Settings.Instance);
            Settings.Instance.language = Language.Espanol;
            UpdateSprites();

            ChangePanel(panel_StartMenu);
        });

        btn_ENG.GetComponent<Button>().onClick.AddListener(() =>
        {
            Settings.Instance.language = Language.English;
            UpdateSprites();
            ChangePanel(panel_StartMenu);
        });

        //StartMentu

        btn_Start.GetComponent<Button>().onClick.AddListener(() =>
        {
            if(Settings.Instance.language == Language.English)
            {
                ChangePanel(panel_TimeSelection_ENG);

            }else if (Settings.Instance.language == Language.Espanol)
            {
                ChangePanel(panel_TimeSelection_ESP);
            }
        });

        btn_Credits.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (Settings.Instance.language == Language.English)
            {
                ChangePanel(panel_Credits_ENG);

            }
            else if (Settings.Instance.language == Language.Espanol)
            {
                ChangePanel(panel_Credits_ESP);
            }
        });

        btn_Exit.GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
        });

        panel_LanguageSelection.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateSprites()
    {
        Sprite[] spriteArray = new Sprite[sprites_ESP.Length];

        switch (Settings.Instance.language)
        {
            case Language.English:
                spriteArray = sprites_ENG;
                break;

            case Language.Espanol:
                spriteArray = sprites_ESP;
                break;
        }

        btn_Start.GetComponent<Image>().sprite = spriteArray[0];
        btn_Credits.GetComponent<Image>().sprite = spriteArray[1];
        btn_Exit.GetComponent<Image>().sprite = spriteArray[2];
    }
    void ChangePanel(GameObject panel)
    {
        panel_LanguageSelection.SetActive(false);
        panel_StartMenu.SetActive(false);
        panel_TimeSelection_ESP.SetActive(false);
        panel_TimeSelection_ENG.SetActive(false);

        panel.SetActive(true);
    }
}
