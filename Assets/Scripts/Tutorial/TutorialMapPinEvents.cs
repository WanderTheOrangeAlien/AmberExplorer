using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialMapPinEvents : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private MeshRenderer rend;
    public ControladorMediaV1_1 mediaController;
    public bool wasInteracted = false;

    [TextArea]
    public string debug;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        mediaController = FindObjectOfType<ControladorMediaV1_1>();
        rend = GetComponent<MeshRenderer>();

        interactable.activated.AddListener((ActivateEventArgs args) =>
        {
            if (!wasInteracted)
            {
                Debug.Log($"{gameObject.name} Incremented MapInteractionCount");
                mediaController.IncrementMapInteractionCount();
            }

            // rend.SetMaterials(new List<Material>
            // {
            //     rend.materials[0],mediaController.DefaultMapPinMaterial
            // });

            wasInteracted = true;
        });

    }

    // Update is called once per frame
    void Update()
    {
        debug = "Grab count= " + ControladorMediaV1_1.mapInteractionCount;
    }
}
