using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorreccionRotacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }


}
