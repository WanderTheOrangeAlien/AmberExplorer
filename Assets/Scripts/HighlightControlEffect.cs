using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightControlEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p;
    public Color baseColor;
    void Start()
    {
        p.GetComponent<Renderer>().material.SetColor("_MainColor", baseColor);

    }


    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log(other);

    //     if (other.name != "Mesa")//en vez de mesa ira el raycast de la mano de la vr
    //     {
    //         p.GetComponent<Renderer>().material.SetColor("_ChangeColor", Color.black);

    //     }
    //     // Comprobar si el objeto que entra en el trigger tiene un Renderer

    //     // Obtener el material del objeto


    // }
    // void ColliderEnter(Collider other)
    // {
    //     p.GetComponent<Renderer>().material.SetColor("_ChangeColor", Color.black);

    // }
}


