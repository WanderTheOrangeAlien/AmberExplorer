using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverPlayer : MonoBehaviour
{
    public AudioClip CaveEnterVoiceOver;
    public AudioClip GameOverVoiceOver;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = CaveEnterVoiceOver;
        audioSource.Play();

        GameManager.Instance.OnGameOver += () =>
        {
            audioSource.clip = GameOverVoiceOver;
            audioSource.Play();
            Debug.Log("GAME OVER");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
