using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VR_CustomHandMAnagement : MonoBehaviour
{
    float watchdogTime; 

    private XRRayInteractor rayInteractor;

    private float defaultRaycastDistance;

    private bool isGrabbing;

    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        defaultRaycastDistance = rayInteractor.maxRaycastDistance;
        watchdogTime = 2 / Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

       //if(timer > Time.deltaTime)
       // {
       //     if (!isGrabbing)
       //     {
       //         EnableRayInteractor();
       //     }
       //     timer = 0;
       // }
       // else
       // {
       //     timer += Time.deltaTime;
       // }
    }

    public void EnableRayInteractor()
    {
        isGrabbing = false;
        rayInteractor.maxRaycastDistance = defaultRaycastDistance;
    }

    public void DisableRayInteractor()
    {
        isGrabbing = true;
        rayInteractor.maxRaycastDistance = 0.01f;
    }

}
