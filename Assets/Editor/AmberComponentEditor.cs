using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AmberComponent)),CanEditMultipleObjects]
public class AmberComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AmberComponent amberComponent = (AmberComponent)target;

        if (GUILayout.Button("Collect"))
        {
            amberComponent.CollectedMethod();
        }

        if (GUILayout.Button("Collect x5"))
        {
            PlayerInventory.Instance.AddItem("amber_blue", 5);
        }
    }
}
