using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRaycastHitEvent : MonoBehaviour
{
    public delegate void RayCastHitDelegate();
    public event RayCastHitDelegate OnRaycastHit;

    public void FireEvent()
    {
        if (OnRaycastHit != null)
            OnRaycastHit();
        else
            Debug.Log("Event was Null!");
    }

    private void Start()
    {
        OnRaycastHit += () => { Debug.Log($"{gameObject.name}: Raycast Hit detected!"); };
    }
}
