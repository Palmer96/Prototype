using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridSlot))]
public class GridSlotEditor : Editor
{

    public override void OnInspectorGUI()
    {
        GridSlot myTarget = (GridSlot)target;

        GUILayout.BeginHorizontal();
        myTarget.toggle11 = GUILayout.Toggle(myTarget.toggle11, "11");
        myTarget.toggle21 = GUILayout.Toggle(myTarget.toggle21, "21");
        myTarget.toggle31 = GUILayout.Toggle(myTarget.toggle31, "31");
        GUILayout.EndHorizontal();                          

        GUILayout.BeginHorizontal();                        
        myTarget.toggle12 = GUILayout.Toggle(myTarget.toggle12, "12");
        myTarget.toggle22 = GUILayout.Toggle(myTarget.toggle22, "22");
        myTarget.toggle32 = GUILayout.Toggle(myTarget.toggle32, "32");
        GUILayout.EndHorizontal();                          

        GUILayout.BeginHorizontal();                        
        myTarget.toggle13 = GUILayout.Toggle(myTarget.toggle13, "13");
        myTarget.toggle23 = GUILayout.Toggle(myTarget.toggle23, "23");
        myTarget.toggle33 = GUILayout.Toggle(myTarget.toggle33, "33");
        GUILayout.EndHorizontal();
    }
}
