using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmberComponent : MonoBehaviour
{
    public delegate void AmberCollected(AmberScriptableObject data);
    public static event AmberCollected OnAmberCollected;
    public AmberScriptableObject amberData;

    public string collectionAreaTag = "Score";

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();

        //meshFilter.mesh = amberData.model;
        meshRenderer.material = amberData.hiddenMaterial;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectionAreaTag)
        {
            Debug.Log($"{gameObject.name}: Detected collection area");
            OnAmberCollected(amberData);
        }
    }
}

/// <summary>
/// Types of Amber
/// </summary>
public enum AmberType
{
    Miel,
    Naranja,
    Rojo,
    Azul
}
[System.Serializable]
public struct AmberInfo_t
{       

    

}