using UnityEngine;

public class CambiarColorFrenteCamara : MonoBehaviour
{
    public Material materialOriginal;
    public Material nuevoMaterial;
    public float velocidadTransicion = 2.0f;

    private Renderer rend;
    private Camera mainCamera;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = materialOriginal;

        mainCamera = Camera.main; // Obtiene la cámara principal
    }

    private void Update()
    {
        Vector3 objectToCamera = mainCamera.transform.position - transform.position;
        float angleToObject = Vector3.Angle(transform.forward, objectToCamera);

        if (angleToObject < 90) // Si el objeto está enfrente de la cámara
        {
            rend.material.color = Color.Lerp(rend.material.color, nuevoMaterial.color, Time.deltaTime * velocidadTransicion);
        }
        else
        {
            rend.material.color = Color.Lerp(rend.material.color, materialOriginal.color, Time.deltaTime * velocidadTransicion);
        }
    }
}

