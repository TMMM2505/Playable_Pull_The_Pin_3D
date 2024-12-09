using System;
using System.Collections.Generic;
using Pancake;
using Pancake.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Icon data config")]
public class IconDataConfig : ScriptableObject
{
    [SerializeField] private string levelFolderPath;
    public List<IconConfig> listIcon;
    public List<IconData> listIconData;
    private List<Level> _listLevels;

    
    #if UNITY_EDITOR
    [Button]
    public void GetData()
    {
        var allNormalLevels = CreateInstance<ObjectList>();
        GetObjectsInFolder(allNormalLevels, levelFolderPath);
        _listLevels = new List<Level>();
        listIconData.Clear();

        foreach (var obj in allNormalLevels.objects)
        {
            var levelScript = obj.GetComponent<Level>();
            if(levelScript != null) _listLevels.Add(levelScript);
        }

        foreach (var level in _listLevels)
        {
            listIconData.Add(new IconData(level.notificationType, level.iconType));
        }
        
        AssetDatabase.SaveAssets();
    }
    
    void GetObjectsInFolder(ObjectList list, string folderPath)
    {
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new string[] { folderPath });
        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            GameObject go = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
            if (go != null)
            {
                list.objects.Add(go);
            }
        }
    }
    #endif
    
    public Sprite GetIconSpriteByType(IconType type)
    {
        var icon = listIcon.FirstOrDefault(icon => icon.type == type);
        if (icon.sprite != null)
            return icon.sprite;
        else
            return null;
    }
}

[Serializable]
public class IconData
{
    public LevelNotificationType notificationType;
    public IconType iconType;

    public IconData(LevelNotificationType notificationType, IconType iconType)
    {
        this.notificationType = notificationType;
        this.iconType = iconType;
    }
}

public class ObjectList : ScriptableObject
{
    public List<GameObject> objects = new List<GameObject>();
}

[Serializable]
public class IconConfig
{
    public IconType type;
    public Sprite sprite;
}

[Serializable]
public enum IconType
{
    None,
    Hard,
    Coin,
    Star,
    Character,
    Chest,
    Notify,
    Unlock,
    Completed,
    ColorBall
}