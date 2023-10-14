using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_2 : MonoBehaviour
{
    public static float time;
    public static float targetTime;

    public static bool isRunning = false;

    public float DEBUG_time;
    public float DEBUG_targetTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DEBUG_time = time;
        DEBUG_targetTime = targetTime;

        if (isRunning)
        {
            time += Time.deltaTime;
        }
        
        if(time >= targetTime && isRunning)
        {
            Debug.LogWarning("TIME RAN OUT!");
            StopTimer();
        }

    }

    public static void StartTimer()
    {
        Debug.Log("Timer Started. Target Time=" + targetTime);
        time = 0;
        isRunning = true;
    }

    public static void StopTimer()
    {
        isRunning = false;
    }

}
