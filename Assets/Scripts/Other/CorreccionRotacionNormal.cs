using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorreccionRotacionNormal : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        // Obtener el objeto Transform
        Transform t = gameObject.transform;

        // Obtener la rotación actual como un vector de Euler
        Vector3 eulerRotation = t.rotation.eulerAngles;

        // Modificar la rotación en el eje X
        eulerRotation.x = -90;

        // Asignar la nueva rotación al objeto Transform
        t.rotation = Quaternion.Euler(eulerRotation);


    }

}
