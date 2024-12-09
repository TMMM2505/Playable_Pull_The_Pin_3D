#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
 
[CustomEditor(typeof(Ball),true),CanEditMultipleObjects]
public class BallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        List<Object> balls = targets.ToList();
        if(GUILayout.Button("Activating", GUILayout.Height(40)))
        {
            foreach (var item in balls)
            {
                var b = item as Ball;
                b.IsActivated = true;
            }
            
            if (PrefabStageUtility.GetCurrentPrefabStage() != null)
            {
                if (balls.Count > 0)
                {
                    var b = balls[0] as Ball;
                    if (b != null)
                    {
                        var prefabContentsRoot = PrefabStageUtility.GetPrefabStage(b.gameObject).prefabContentsRoot;
                        if (prefabContentsRoot != null) EditorUtility.SetDirty(prefabContentsRoot);
                    }
                }
            }
        }
        if(GUILayout.Button("Deactivating", GUILayout.Height(40)))
        {
            foreach (var item in balls)
            {
                var b = item as Ball;
                b.IsActivated = false;
            }
            
            if (PrefabStageUtility.GetCurrentPrefabStage() != null)
            {
                if (balls.Count > 0)
                {
                    var b = balls[0] as Ball;
                    if (b != null)
                    {
                        var prefabContentsRoot = PrefabStageUtility.GetPrefabStage(b.gameObject).prefabContentsRoot;
                        if (prefabContentsRoot != null) EditorUtility.SetDirty(prefabContentsRoot);
                    }
                }
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif