using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectClick : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip soundClip; // El sonido que deseas reproducir

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtén la referencia al componente AudioSource
    }

    public void PlaySound()
    {
        audioSource.clip = soundClip; // Establece el sonido a reproducir
        audioSource.Play(); // Reproduce el sonido
    }
}
