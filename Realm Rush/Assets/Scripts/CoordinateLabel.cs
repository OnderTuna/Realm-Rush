using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    private Vector2Int tileCoordinate = new Vector2Int();
    private TextMeshPro coordinateText;
    private Waypoint waypointScript;
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color fadedColor = Color.white;

    void Awake()
    {
        waypointScript = GetComponentInParent<Waypoint>();
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
        ColorTheCoordinates();
        ToogleCoordinates();
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

    private void ColorTheCoordinates()
    {
        if(waypointScript.IsPlaceable)
        {
            coordinateText.color = defaultColor;
        }
        else
        {
            coordinateText.color = fadedColor;
        }
    }

    private void ToogleCoordinates()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            coordinateText.enabled = !coordinateText.enabled;
        }
    }
}
