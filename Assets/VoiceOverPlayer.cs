using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverPlayer : MonoBehaviour
{
    public AudioClip CaveEnterVoiceOver_ESP;
    public AudioClip CaveEnterVoiceOver_ENG;

    public AudioClip GameOverVoiceOver_ESP;
    public AudioClip GameOverVoiceOver_ENG;

    private AudioClip CaveEnterVoiceOver;
    private AudioClip GameOverVoiceOver;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        switch (GlobalSettings.Instance.language)
        {
            case Language.English:
                GameOverVoiceOver = GameOverVoiceOver_ENG;
                CaveEnterVoiceOver = CaveEnterVoiceOver_ENG;
                break;

            case Language.Espanol:
                GameOverVoiceOver = GameOverVoiceOver_ESP;
                CaveEnterVoiceOver = CaveEnterVoiceOver_ESP;
                break;
        }

        audioSource.clip = CaveEnterVoiceOver;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
