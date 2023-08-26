using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MnageShaderColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p;
    public Color baseColor;
    void Start()
    {
        p.GetComponent<Renderer>().material.SetColor("_MainColor", baseColor);

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        if (other.name == "Mesa")//en vez de mesa ira el raycast de la mano de la vr
        {

        }
        // Comprobar si el objeto que entra en el trigger tiene un Renderer

        // Obtener el material del objeto
        p.GetComponent<Renderer>().material.SetColor("_ChangeColor", Color.black);


    }
    // void ColliderEnter(Collider other)
    // {
    //     p.GetComponent<Renderer>().material.SetColor("_ChangeColor", Color.black);

    // }
}
