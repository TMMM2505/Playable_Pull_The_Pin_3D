#if UNITY_EDITOR
using System.Collections.Generic;
using Pancake;
using TMPro;
using UnityEngine;

public class AStar : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float offset;
    [SerializeField] private Transform elementPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private List<Transform> elementList;

    [Button]
    public void GenerateEnvironment()
    {
        container.Clear();
        elementList.Clear();

        var elementSize = elementPrefab.rectTransform().rect.height;
        var middleIndex = (float)(size - 1) / 2;

        for (var row = 0; row < size; row++)
        {
            for (var column = 0; column < size; column++)
            {
                var element = Instantiate(elementPrefab, container);
                element.rectTransform().anchorMin = Vector2.one * 0.5f;
                element.rectTransform().anchorMax = Vector2.one * 0.5f;

                var distanceToMiddleX = (column - middleIndex) * (elementSize + offset);
                var distanceToMiddleY = (middleIndex - row) * (elementSize + offset);
                element.localPosition = new Vector2(distanceToMiddleX, distanceToMiddleY);

                elementList.Add(element);
            }
        }

        for (var i = 0; i < elementList.Count; i++)
        {
            var text = elementList[i].GetComponentInChildren<TextMeshProUGUI>();
            text.SetText($"{i / size + 1}x{i % size + 1}");
        }
    }
}
#endif