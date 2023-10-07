using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Canvas_TimeSelectionV2 : MonoBehaviour
{

    public static int selectedTime = 0;

    public TimeOption[] timeOptions = new TimeOption[3];
    public Button btn_Continue;
    public GameObject[] ambaritos = new GameObject[3];

    private ColorBlock defaultColorBlock;
    private ColorBlock selectedColorBlock;

    private bool isTimeSelected = false;
    private int selectedOption = -1;

    // Start is called before the first frame update
    void Start()
    {
        defaultColorBlock = timeOptions[0].button.colors;
        selectedColorBlock = timeOptions[0].button.colors;

        selectedColorBlock.normalColor = new Color(1, 1, 1, 0.58f);
        selectedColorBlock.selectedColor = new Color(1, 1, 1, 0.58f);

        for (int i = 0; i < timeOptions.Length; i++)
        {
            int index = i;
            timeOptions[i].button.onClick.AddListener(() =>
            {
                SelectOption(index);
            });
        }

        btn_Continue.onClick.AddListener(() =>
        {
            if (isTimeSelected)
            {
                TimerController.targetTime = selectedTime;
                Debug.Log($"TimeSelected={TimerController.targetTime}");


                //DEBUG
                FindObjectOfType<SceneTransition>().ChangeScene(2, "Home_V2.1");

                //INTENDED
                //FindObjectOfType<SceneTransition>().ChangeScene(2, "Home_V2.1");
            }

        });

        for (int i = 0; i < timeOptions.Length; i++)
        {
                
                ambaritos[i].SetActive(false);

        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    void SelectOption(int index)
    {
        isTimeSelected = true;

        for (int i = 0; i < timeOptions.Length; i++)
        {
            //Debug.Log($"Target Index is {index}. Current={i}");
            if (i == index)
            {

                ambaritos[index].SetActive(true);

                selectedTime = timeOptions[index].time;
                selectedOption = index;
            }
            else
            {
                ambaritos[i].SetActive(false);
            }

        }
    }

    public void HighlightOption(int id)
    {
        for (int i = 0; i < timeOptions.Length; i++)
        {
            //Debug.Log($"Target Index is {index}. Current={i}");
            if (i == id)
            {

                ambaritos[id].SetActive(true);
            }
            else if (i != selectedOption)
            {
                ambaritos[i].SetActive(false);
            }

        }
    }

    public void UnhighlightOption(int id)
    {
        for (int i = 0; i < timeOptions.Length; i++)
        {
            //Debug.Log($"Target Index is {index}. Current={i}");
            if (i != selectedOption)
            {

                ambaritos[i].SetActive(false);
            }

        }
    }
}
