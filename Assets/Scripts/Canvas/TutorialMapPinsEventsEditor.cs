using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TutorialMapPinEvents))]
public class TutorialMapPinEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Increment"))
        {
            ((TutorialMapPinEvents)target).mediaController.IncrementMapInteractionCount();
        }
    }
}
