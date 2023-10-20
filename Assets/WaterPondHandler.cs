using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPondHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[{other.gameObject.name}] entered trigger of [{gameObject.name}]");

        if(other.gameObject.tag == "Player")
        {
            Footsteps footstepComponent = other.gameObject.GetComponent<Footsteps>();

            footstepComponent.audioSource.Stop();
            footstepComponent.audioSource.clip = footstepComponent.sounds.water;
            footstepComponent.audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Footsteps footstepComponent = other.gameObject.GetComponent<Footsteps>();
            footstepComponent.audioSource.Stop();
            footstepComponent.audioSource.clip = footstepComponent.sounds.defaultSound;
            footstepComponent.audioSource.Play();
        }
    }
}
