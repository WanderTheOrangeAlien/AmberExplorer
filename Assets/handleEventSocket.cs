using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleEventSocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Reposa chaleco")
        {

            Settings.Instance.checkBaseChalecoDeSeguridad = true;
            Settings.Instance.checkKeyChaleco = true;

        }


    }
}
