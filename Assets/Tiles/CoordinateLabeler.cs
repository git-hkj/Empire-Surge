using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]

public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    
    TextMeshPro label;
    Vector2Int coordinates =  new Vector2Int();
    WayPoint wayP;

    //Unity is awakened
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        wayP = GetComponentInParent<WayPoint>(); 
        DisplayCoordinate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)     //to make sure the changes don't happen during game
        {
            DisplayCoordinate();
            UpdateObjectName();
            label.enabled = true;
        }
        SetLabelColor();
        ToggleLabels();
    }

    //to change color based on the status of the grid point
    void SetLabelColor()
    {
        if (wayP.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }
    
    //to turn the label on and off
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            label.enabled = !label.IsActive();
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
