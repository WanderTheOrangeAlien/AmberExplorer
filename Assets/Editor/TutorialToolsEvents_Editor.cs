using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TutorialToolEvents))]
public class TutorialToolsEvents_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Increment"))
        {
            ((TutorialToolEvents)target).mediaController.IncrementGrabCount();
        }
    }
}
