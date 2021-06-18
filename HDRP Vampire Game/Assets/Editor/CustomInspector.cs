using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InspectablesList))]
public class CustomInspector : Editor
{
    private int number;
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //number = int.Parse(GUILayout.TextField(number.ToString(), 2));
        try
        {
            number = int.Parse(EditorGUILayout.TextField("Details:", number.ToString()));
        }
        catch
        {
            
        }
        InspectablesList script = (InspectablesList) target;
        if (GUILayout.Button("Create List") && number >= 0 )
        {
            script.CreateInspectablesList(number + 1);
        }

    }
}
