using System;
using Pancake;
using UnityEngine;

public class Element : ObjectCircle
{
    public TypeElement typeElement;
}

public enum TypeElement
{
    Single,
    Multi
}

[Serializable]
public class TransformElement
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = Vector3.one;

    public void SetupTransformElement(Transform transformElement)
    {
        transformElement.localPosition = position;
        transformElement.localRotation = Quaternion.Euler(rotation);
        transformElement.localScale = scale;
    }
}