using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToolHightlight : MonoBehaviour
{
    private Material defaultMaterial;
    private Renderer renderer;
    private XRGrabInteractable grabInteractable;

    public Material highlightMaterial;
    public bool highlightByDefault;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener((SelectEnterEventArgs args) =>
        {
            renderer.material = defaultMaterial;
        });

        if (highlightByDefault)
        {
            renderer.material = highlightMaterial;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
