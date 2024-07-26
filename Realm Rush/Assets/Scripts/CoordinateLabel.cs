using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    private Vector2Int tileCoordinate = new Vector2Int();
    private TextMeshPro coordinateText;

    void Awake()
    {
        coordinateText = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateTileName();
        }
    }

    private void DisplayCoordinates()
    {
        tileCoordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        tileCoordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        coordinateText.text = $"{tileCoordinate.x}, {tileCoordinate.y}";
    }

    private void UpdateTileName()
    {
        transform.parent.name = tileCoordinate.ToString();
    }
}
