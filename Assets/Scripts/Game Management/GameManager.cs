using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Item> GameItems;
    public AudioClip gameOverVoiceOver;
    public bool isGameOver = false;

    public delegate void GameOver();
    public event GameOver OnGameOver;

    private AudioSource audioSource;

    public static GameManager Instance;
    


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public void InvokeGameOver()
    {
        isGameOver = true;
        OnGameOver();
        
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool ItemExists(string id)
    {
        try
        {
            return GameItems.Find(x => x.id == id);
        }
        catch
        {
            return false;
        }
        
    }
}
