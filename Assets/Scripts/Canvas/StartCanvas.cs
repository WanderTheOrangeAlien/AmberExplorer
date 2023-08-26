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
    [Space(10)]
    public Sprite[] sprites_ESP;
    public Sprite[] sprites_ENG;
    


    // Start is called before the first frame update
    void Start()
    {
        panel_StartMenu.SetActive(false);

        btn_ESP.GetComponent<Button>().onClick.AddListener(() =>
        {
            Settings.Instance.language = Language.Espanol;
            UpdateSprites();
            panel_LanguageSelection.SetActive(false);
            panel_StartMenu.SetActive(true);
        });

        btn_ENG.GetComponent<Button>().onClick.AddListener(() =>
        {
            Settings.Instance.language = Language.English;
            UpdateSprites();
            panel_LanguageSelection.SetActive(false);
            panel_StartMenu.SetActive(true);
        });

        //StartMentu

        btn_Start.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Home_V1.2");
        });

        btn_Exit.GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
        });
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
}
