using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        GetComponent<Canvas>().worldCamera = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        
    }
}
