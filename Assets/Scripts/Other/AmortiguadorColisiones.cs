using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmortiguadorColisiones : MonoBehaviour
{
    public float dampingForce = 5.0f; // Define la fuerza de amortiguación que se aplicará

    private Rigidbody rb; // Referencia al componente Rigidbody del objeto

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calcula la dirección del rebote
        Vector3 reboundDirection = collision.contacts[0].normal;

        // Aplica una fuerza en sentido contrario al rebote
        rb.AddForce(-reboundDirection * dampingForce, ForceMode.Impulse);
    }
}
