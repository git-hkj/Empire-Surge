using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [Tooltip("To define where defense can be placed")][SerializeField] bool isPlaceable;
    //defining a property to make the bool more accessable 
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    //Unity is awakened
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
               gridManager.BlockedNode(coordinates); 
            }
        }
    }

    //To perform action when mouse button are clicked
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool canAfford = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !canAfford; 
        }
    }
}
