using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"[Game Info]: Gravity={Physics.gravity}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogDebug()
    {
        Debug.Log($"{gameObject.name}: Responded to event");
    }
}
