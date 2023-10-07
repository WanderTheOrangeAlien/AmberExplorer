using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_TimeSelection : MonoBehaviour
{

    public static int selectedTime = 0;

    public TimeOption[] timeOptions = new TimeOption[3];
    public Button btn_Continue;

    private ColorBlock defaultColorBlock;
    private ColorBlock selectedColorBlock;

    private bool isTimeSelected = false;

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
                FindObjectOfType<SceneTransition>().ChangeScene(2, "Example");

                //INTENDED
                //FindObjectOfType<SceneTransition>().ChangeScene(2, "Home_V2.1");
            }

        });
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
            Debug.Log($"Target Index is {index}. Current={i}");
            if (i == index)
            {

                timeOptions[i].button.colors = selectedColorBlock;

                Debug.Log(timeOptions[i].button.name + " (Target): Changed ColorBlock. normal = " + timeOptions[i].button.colors.normalColor);

                selectedTime = timeOptions[i].time;
            }
            else
            {
                timeOptions[i].button.colors = defaultColorBlock;
                Debug.Log(timeOptions[i].button.name + ": Changed ColorBlock. normal = " + timeOptions[i].button.colors.normalColor);
            }

        }
    }
}

[System.Serializable]
public struct TimeOption
{
    public Button button;
    public int time;
}
