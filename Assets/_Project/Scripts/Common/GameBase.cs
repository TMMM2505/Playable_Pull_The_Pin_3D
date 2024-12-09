#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
public class GameBase : EditorWindow
{
    void OnGUI()
    {
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.EndHorizontal();
    }
    
    [MenuItem("GameBase/OPEN SCENE/Loading Scene %F1")]
    public static void PlayFromLoadingScene(){
        EditorSceneManager.OpenScene($"Assets/_Project/Scenes/{Constant.LOADING_SCENE}.unity");
    }

    [MenuItem("GameBase/OPEN SCENE/Gameplay Scene %F2")]
    public static void PlayFromGamePlayScene(){
        EditorSceneManager.OpenScene($"Assets/_Project/Scenes/{Constant.GAMEPLAY_SCENE}.unity");
    } 

    
    [MenuItem("GameBase/Data/Clear")]
    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
        
        if (EditorUtility.DisplayDialog("Clear Persistent Data Path",
                "Are you sure you wish to clear the persistent data path?\n This action cannot be reversed.",
                "Clear",
                "Cancel"))
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.persistentDataPath);

            foreach (System.IO.FileInfo file in di.GetFiles())
                file.Delete();
            foreach (System.IO.DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }
    }
    
    [MenuItem("GameBase/Data/Add 100000 coins")]
    public static void AddCoin()
    {
        //Data.CurrencyTotal += 100000;
    }
}
#endif
