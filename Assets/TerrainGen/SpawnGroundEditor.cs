using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnGround))]
public class SpawnGroundEditor : Editor
{
    public override void OnInspectorGUI()
    {

        SpawnGround myTarget = (SpawnGround)target;
        

        if (GUILayout.Button("Change View"))
        {
            myTarget.ChangeView();
        }
        if (GUILayout.Button("Height"))
        {
            myTarget.SetTool(SpawnGround.Tool.Height);
        }
        if (GUILayout.Button("Height Set"))
        {
            myTarget.SetTool(SpawnGround.Tool.HeightSet);
        }
        if (GUILayout.Button("Paint 1"))
        {
            myTarget.SetTool(SpawnGround.Tool.Paint1);
        }
        if (GUILayout.Button("Paint 2"))
        {
            myTarget.SetTool(SpawnGround.Tool.Paint2);
        }
        if (GUILayout.Button("Paint 3"))
        {
            myTarget.SetTool(SpawnGround.Tool.Paint3);
        }
        if (GUILayout.Button("Decal"))
        {
            myTarget.SetTool(SpawnGround.Tool.Decal);
        }

        DrawDefaultInspector();
    }

}
