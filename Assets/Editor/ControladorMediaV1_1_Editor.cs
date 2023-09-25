using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ControladorMediaV1_1))]
public class ControladorMediaV1_1_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ControladorMediaV1_1 controller = (ControladorMediaV1_1)target;

        if(GUILayout.Button("Highlight Trigger"))
        {
            controller.HighlightTrigger();
        }

        if (GUILayout.Button("Highlight Pins"))
        {
            controller.ChangeHighlight(controller.MapPins, controller.HighlitedMapPinMaterial);
        }

        if (GUILayout.Button("Unhighlight Pins"))
        {
            controller.ChangeHighlight(controller.MapPins, controller.DefaultMapPinMaterial);
        }

        if (GUILayout.Button("Highlight Tools"))
        {
            controller.ChangeHighlight(controller.Tools, controller.HighlitedToolMaterial);
        }

        if (GUILayout.Button("Unhighlight Tools"))
        {
            controller.ChangeHighlight(controller.Tools, controller.DefaultToolMaterial);
        }
    }
}
