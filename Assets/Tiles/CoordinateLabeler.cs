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

    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor     = new Color(1f,0f,0.5f); //to create orange using RGB scales

    TextMeshPro label;
    Vector2Int coordinates =  new Vector2Int();
    GridManager gridManager;

    //Unity is awakened
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
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
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return;}

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
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
