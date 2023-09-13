using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AmberScriptableObject", order = 1)]
public class AmberScriptableObject : ScriptableObject
{
    public AmberType amberType;
    [Space(10)]

    public string itemID;
    public Material ambarMaterial;
}
