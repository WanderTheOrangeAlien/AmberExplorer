using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
	[SerializeField] 
	public static int min, seg; // Minutos y segundos iniciales configurables desde el Inspector
	
	[SerializeField] 
	string timeString; // Referencia al componente de texto para mostrar el tiempo
	
	[SerializeField] 
	Canvas gameOverCanvas; // Arrastra el Canvas de Game Over desde el Inspector

	public TMP_Text timerText;

	public string debug_Time;

	public static long startTimeStamp;
	public static long endTimeStamp;

	public static int targetTime; // Tiempo restante en segundos
	public static int remaningTime;
	public static DateTime targetDateTime;
	public static bool enMarcha; // Indica si el contador de tiempo está en marcha

	private void Awake()
	{

		// Asegura que el Canvas de Game Over esté desactivado al inicio
		if (gameOverCanvas != null)
		{
			gameOverCanvas.gameObject.SetActive(false);
		}
	}

    private void Start()
    {
		Time.timeScale = 1;

		if(debug_Time == "DEBUG_30S")
        {
			targetTime = 10;
			StartTimer();

        }
    }

    void FixedUpdate()
	{
		if (enMarcha)
		{
			remaningTime = getSecondsLeft(targetDateTime);


			if (remaningTime <= 0)
			{
				// El tiempo ha llegado a cero
				enMarcha = false;
				remaningTime = 0;

				GameManager.Instance.GameOver(GameOverCause.TimeOver);

				// Pausa el juego
				//Time.timeScale = 0f;
				GameOver.isGameOver = true;
			}
		}

		// Resto del código para mostrar el tiempo
		
		int tempmin = Mathf.FloorToInt(remaningTime / 60);
		int tempSeg = Mathf.FloorToInt(remaningTime % 60);
		timeString = string.Format("{00:00}:{01:00}", tempmin, tempSeg);
		debug_Time = remaningTime.ToString();

		if(timerText != null)
        {
			timerText.text = timeString;
		}
		
	}

	public static void StartTimer()
    {

		// Inicializa el contador de tiempo como en marcha
		enMarcha = true;
		targetDateTime = DateTime.Now.AddSeconds(targetTime);


		Debug.Log($"Target={targetTime.ToString()} Length={targetTime}");

	}

	public int getSecondsLeft(DateTime target)
	{
		//Create Desired time

		//Get the current time
		DateTime now = DateTime.Now;

		//Convert both to seconds
		int targetSec = target.Hour * 60 * 60 + target.Minute * 60 + target.Second;
		int nowSec = now.Hour * 60 * 60 + now.Minute * 60 + now.Second;

		//Get the difference in seconds
		int diff = targetSec - nowSec;

		return diff;
	}

}
