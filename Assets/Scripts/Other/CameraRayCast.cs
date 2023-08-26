using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public bool enableRaycasting;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position,
        Color.blue);

        if (Input.GetMouseButtonDown(0) && enableRaycasting)
        {
            //Debug.Log("Raycasting!");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            ray.direction *= 100;
            Debug.DrawRay(ray.origin, ray.direction , Color.red);
 
            if (Physics.Raycast(ray, out hit, 1000,mask))
            {
                Debug.Log($"Camera: Hit: " + hit.transform.name);
                hit.transform.GetComponent<OnRaycastHitEvent>().FireEvent();

            }
        }
    }
}
