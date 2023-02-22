using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates =  new Vector2Int();

    //Unity is awakened
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinate();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)     //to make sure the changes dont happen during game
        {
            DisplayCoordinate();
            UpdateObjectName();
        }
    }

    //to display the coordinate of the tiles
    void DisplayCoordinate()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    //To update the object name after the position change
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
