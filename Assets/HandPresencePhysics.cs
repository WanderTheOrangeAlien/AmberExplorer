using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By Valem Tutorials
public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Transform attachPoint;
    public float threshold;
    public float velocityDamping;
    public float velocityScale;

    private Vector3 starLocaltPos;
    private Quaternion startLocalRot;

    [TextArea]
    public string debugString;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        starLocaltPos = transform.localPosition;
        startLocalRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 distanceVec = (target.position - attachPoint.position);
        Vector3 computedVelocity = distanceVec / Time.fixedDeltaTime;

        //From XR Grab Interactable
        //rb.velocity *= (1f - velocityDamping);
        //var positionDelta = target.position - attachPoint.position;
        //var velocity = positionDelta / Time.fixedDeltaTime;
        //rb.velocity += (velocity * velocityScale);

        if (distanceVec.magnitude > threshold)
        {
            rb.velocity = Vector3.zero;
            transform.localPosition = starLocaltPos;
            
        }

        if (rb.angularVelocity.magnitude > threshold)
        {
            rb.angularVelocity = Vector3.zero;
            transform.localRotation = startLocalRot;
        }

        //Rotation / Angular Vel
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegrees = angleInDegree * rotationAxis;

        rb.angularVelocity = rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime;

        debugString = $"{rb.velocity}\nMagnotude:{rb.velocity.magnitude}";
        Debug.DrawLine(attachPoint.position, target.position, Color.green);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"[{gameObject.name}] Collided with {collision.collider.gameObject.name}");
    }
}
