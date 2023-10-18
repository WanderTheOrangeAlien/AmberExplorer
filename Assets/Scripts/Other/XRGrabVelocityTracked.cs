using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabVelocityTracked : XRGrabInteractable
{ 
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (GameManager.Instance.isXRGrabOverriden)
        {
            SetParentToXRRig();
        }
        
        base.OnSelectEntered(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        if (GameManager.Instance.isXRGrabOverriden)
        {
            SetParentToWorld();
        }        
        base.OnSelectExited(interactor);
    }

    public void SetParentToXRRig()
    {
        transform.SetParent(selectingInteractor.transform);
    }

    public void SetParentToWorld()
    {
        transform.SetParent(null);
    }
}
