using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambiarColorMaterial : MonoBehaviour
{
    public Material materialOriginal; // Material original del objeto
    public Material nuevoMaterial; // Material con el nuevo color
    public float velocidadTransicion = 2.0f; // Velocidad de transición

    private Renderer rend; // Componente Renderer del objeto
    private bool isHovering = false; // Controla si el mouse está sobre el objeto

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = materialOriginal; // Establece el material original al inicio
    }

    private void OnMouseEnter()
    {
        if (rend != null)
        {
            isHovering = true;
        }
    }

    private void OnMouseExit()
    {
        if (rend != null)
        {
            isHovering = false;
        }
    }

    private void Update()
    {
        if (isHovering)
        {
            // Interpola gradualmente el color del material
            rend.material.color = Color.Lerp(rend.material.color, nuevoMaterial.color, Time.deltaTime * velocidadTransicion);
        }
        else
        {
            // Interpola gradualmente de regreso al color original
            rend.material.color = Color.Lerp(rend.material.color, materialOriginal.color, Time.deltaTime * velocidadTransicion);
        }
    }
}