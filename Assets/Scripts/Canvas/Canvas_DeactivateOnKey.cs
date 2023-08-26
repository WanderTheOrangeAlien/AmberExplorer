using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_DeactivateOnKey : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode key;
    private bool active = true;
    void Start()
    {
        gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            active = !active;
            gameObject.SetActive(active);
        }
    }

   
}
