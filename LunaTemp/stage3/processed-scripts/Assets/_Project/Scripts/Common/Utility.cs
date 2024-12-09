using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utility
{
    public static void Clear(this Transform transform)
    {
        var childCount = transform.childCount;

        for (var i = childCount - 1; i >= 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }

    public static float GetScreenRatio()
    {
        return 1920f / 1080f / (Screen.height / (float)Screen.width);
    }

    public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
    {
        var t = parent.transform;

        return (from Transform tr in t where tr.CompareTag(tag) select tr.GetComponent<T>()).FirstOrDefault();
    }

    public static void SetGameLayerRecursive(GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform child in go.transform)
        {
            child.gameObject.layer = layer;

            var hasChildren = child.GetComponentInChildren<Transform>();
            if (hasChildren != null)
                SetGameLayerRecursive(child.gameObject, layer);
        }
    }

    public static string GetSplitCapitalString(string strInput)
    {
        var result = "";

        foreach (var letter in strInput)
        {
            if (char.IsUpper(letter) && letter != strInput[0])
            {
                result += " " + letter;
            }
            else
            {
                result += letter;
            }
        }

        return result;
    }
}