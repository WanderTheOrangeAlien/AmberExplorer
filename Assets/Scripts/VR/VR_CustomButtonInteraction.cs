using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VR_CustomButtonInteraction : MonoBehaviour
{

    public InputActionProperty MenuButton;

    // Start is called before the first frame update
    void Start()
    {
        MenuButton.action.performed += (InputAction.CallbackContext context) => {
            Canvas_AmberHandler.InvokeToggleUI();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
