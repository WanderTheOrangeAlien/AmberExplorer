using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class handleDetectionCasco : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rayCastLeftHand;
    void Start()
    {
        if (rayCastLeftHand == null)
        {
            rayCastLeftHand.GetComponent<GameObject>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
