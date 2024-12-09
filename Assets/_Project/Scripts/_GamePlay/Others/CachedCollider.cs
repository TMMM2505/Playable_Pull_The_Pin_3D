using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachedCollider
{
    private static readonly Dictionary<Collider2D, ObjectCircle> ObjectCirclesDictionary = new();

    public static ObjectCircle GetObjectCircle(Collider2D collider)
    {
        if (ObjectCirclesDictionary.TryGetValue(collider, out var objectCircle)) return objectCircle;

        if (collider.TryGetComponent<ObjectCircle>(out var returnObject))
        {
            ObjectCirclesDictionary.Add(collider, returnObject);
            return ObjectCirclesDictionary[collider];
        }

        return null;
    }
}