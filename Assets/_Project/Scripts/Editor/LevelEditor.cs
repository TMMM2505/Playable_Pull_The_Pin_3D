using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Level level = (Level)target;

        GUI.color = Color.white;
        DrawDefaultInspector();
        EditorGUILayout.Space();

        if (GUILayout.Button("PLAY THIS LEVEL", GUILayout.Height(60)))
        {
            string currentLevelName = level.gameObject.name;
            string levelStr = currentLevelName.Substring(6);
            Data.CurrentLevel = Int32.Parse(levelStr);
            EditorApplication.isPlaying = true;
        }
        
        // if (GUILayout.Button("CALCULATE TOTAL POINT CAN GET", GUILayout.Height(60)))
        // {
        //     level.UpdateTotalScoreCanGet();
        // }

        GUI.color = Color.white;

        serializedObject.ApplyModifiedProperties();
    }
}



[CustomEditor(typeof(LevelColorBall))]
public class LevelColorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Level level = (Level)target;

        GUI.color = Color.white;
        DrawDefaultInspector();
        EditorGUILayout.Space();

        if (GUILayout.Button("PLAY THIS LEVEL", GUILayout.Height(60)))
        {
            string currentLevelName = level.gameObject.name;
            string levelStr = currentLevelName.Substring(6);
            Data.CurrentLevel = Int32.Parse(levelStr);
            EditorApplication.isPlaying = true;
        }
        GUI.color = Color.white;

        serializedObject.ApplyModifiedProperties();
    }
}
