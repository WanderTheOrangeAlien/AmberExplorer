using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource = GetComponent<AudioSource>();
        // Debug.Log(other.name);
        // Debug.Log(other.tag);
        // if (other.CompareTag("Destroyer"))
        // {
        //     audioSource.Play();
        // }
        if (other.name == "Jarro De Barro")
        {
            audioSource.Play();
        }

    }
}
