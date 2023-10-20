using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Footsteps : MonoBehaviour
{
    public FootstepsSounds sounds;
    public AudioSource audioSource;

    public float stepThreshold;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource.clip = sounds.defaultSound;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"[{gameObject.name}] Velocity magnitude={characterController.velocity.magnitude}");

        if (characterController.velocity.magnitude >= stepThreshold)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}

[System.Serializable]
public struct FootstepsSounds
{
    public AudioClip defaultSound;
    public AudioClip rock;
    public AudioClip water;
    public AudioClip grass;
}
