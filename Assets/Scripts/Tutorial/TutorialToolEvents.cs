using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialToolEvents : MonoBehaviour
{
    private XRGrabInteractable grabbable;
    private MeshRenderer rend;
    public ControladorMediaV1_1 mediaController;
    private bool wasGrabbed = false;

    [TextArea]
    public string debug;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        mediaController = FindObjectOfType<ControladorMediaV1_1>();
        rend = GetComponent<MeshRenderer>();


        grabbable.selectEntered.AddListener((args) =>
        {
            if (!wasGrabbed)
            {
                mediaController.IncrementGrabCount();
            }

            rend.SetMaterials(new List<Material>
            {
                rend.materials[0],mediaController.DefaultToolMaterial
            });

            wasGrabbed = true;
        });

    }

    // Update is called once per frame
    void Update()
    {
        debug = "Grab count= " + ControladorMediaV1_1.grabCount;
    }
}
