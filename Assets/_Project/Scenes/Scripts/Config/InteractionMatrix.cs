using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pancake.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "Config/Interaction Matrix")]
public class InteractionMatrix : ScriptableObject
{
    public List<ElementInteraction> elementInteractions;
    public List<CircleObjectElement> listElements;

    private CircleObjectElement FindCircleObjectWithType(ObjectType objectType)
    {
        return listElements.FirstOrDefault(circleObject => circleObject.type == objectType);
    }

    private ElementInteraction GetElementInteractionResult(ObjectType actingObject, ObjectType affectedObject)
    {
        foreach (var interaction in elementInteractions)
        {
            if (interaction.actingElement == actingObject && interaction.affectedElement == affectedObject)
                return interaction;
        }

        return null;
    }

    public void OnCircleObjectTrigger(ObjectCircle actingObject, ObjectCircle affectedObject)
    {
        var currentInteraction = GetElementInteractionResult(actingObject.Type, affectedObject.Type);
        if (currentInteraction != null)
        {
            //spawn new object
            if (currentInteraction.elementResult != ObjectType.Null)
            {
                var prefab = FindCircleObjectWithType(currentInteraction.elementResult).prefab;
                Instantiate
                (
                    prefab,
                    affectedObject.transform.position,
                    quaternion.identity,
                    affectedObject.GetComponentInParent<Level>().transform
                );
            }

            //sound, effect
            if (currentInteraction.sound != null)
            {
                Debug.Log("sound");
            }
            if (currentInteraction.fx != null)
            {
                Instantiate
                (
                    currentInteraction.fx,
                    affectedObject.transform.position,
                    Quaternion.identity,
                    affectedObject.GetComponentInParent<Level>().transform
                );
            }
            
            //destroy object
            if (!currentInteraction.dontDestroyActingElement) Destroy(actingObject.gameObject);
            if (!currentInteraction.dontDestroyAffectedElement) Destroy(affectedObject.gameObject);
        }
    }
}

[Serializable]
public class CircleObjectElement
{
    public ObjectType type;
    public GameObject prefab;
}

[Serializable]
public class ElementInteraction
{
    public ObjectType actingElement;
    public ObjectType affectedElement;
    public ObjectType elementResult;
    public bool dontDestroyActingElement;
    public bool dontDestroyAffectedElement;
    public GameObject fx;
    public AudioClip sound;
}

#region GUI style

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(ElementInteraction))]
public class ElementInteractionDrawer : PropertyDrawer
{
    private readonly int _fieldAmount = 5;
    private readonly float _padding = 3;
    private readonly float _signWidth = 10;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var element1 = property.FindPropertyRelative("actingElement");
        var element2 = property.FindPropertyRelative("affectedElement");
        var elementResult = property.FindPropertyRelative("elementResult");
        var dontDestroyActingElement = property.FindPropertyRelative("dontDestroyActingElement");
        var dontDestroyAffectedElement = property.FindPropertyRelative("dontDestroyAffectedElement");
        var fx = property.FindPropertyRelative("fx");
        var sound = property.FindPropertyRelative("sound");

        var width = (position.width - (_signWidth + _padding) * 5 - 3) / _fieldAmount;

        var element1Rect = new Rect(position.x, position.y, width, position.height);

        var endElement1RectX = position.x + width;
        var plusRect = new Rect(endElement1RectX + _padding, position.y, _signWidth, position.height);

        var endPlusRectX = endElement1RectX + _padding + _signWidth;
        var element2Rect = new Rect(endPlusRectX + _padding, position.y, width, position.height);

        var endElement2RectX = endPlusRectX + _padding + width;
        var equalRect = new Rect(endElement2RectX + _padding, position.y, _signWidth, position.height);

        var endEqualRectX = endElement2RectX + _padding + _signWidth;
        var elementResultRect = new Rect(endEqualRectX + _padding, position.y, width, position.height);

        var endElementResultRectX = endEqualRectX + _padding + width;
        var fxRect = new Rect(endElementResultRectX + _padding, position.y, width, position.height);

        var endFxRect = endElementResultRectX + _padding + width;
        var soundRect = new Rect(endFxRect + _padding, position.y, width, position.height);

        var endSoundRect = endFxRect + _padding + width;
        var destroyRect = new Rect(endSoundRect + _padding, position.y, _signWidth, position.height);

        var endActingRect = endSoundRect + _padding + _signWidth + 3;
        var destroyAffectedRect = new Rect(endActingRect + _padding, position.y, _signWidth, position.height);

        GUIStyle style = new GUIStyle
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            normal =
            {
                textColor = Color.white
            }
        };

        EditorGUI.PropertyField(element1Rect, element1, GUIContent.none);
        EditorGUI.LabelField(plusRect, "+", style);
        EditorGUI.PropertyField(element2Rect, element2, GUIContent.none);
        EditorGUI.LabelField(equalRect, "=", style);
        EditorGUI.PropertyField(elementResultRect, elementResult, GUIContent.none);
        EditorGUI.PropertyField(fxRect, fx, GUIContent.none);
        EditorGUI.PropertyField(soundRect, sound, GUIContent.none);
        EditorGUI.PropertyField(destroyRect, dontDestroyActingElement, GUIContent.none);
        EditorGUI.PropertyField(destroyAffectedRect, dontDestroyAffectedElement, GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}

#endif

#endregion