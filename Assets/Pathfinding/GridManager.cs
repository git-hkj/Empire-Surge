using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Tooltip("Define the grid size")]
    [SerializeField] Vector2Int gridSize;
    [Tooltip("Size of the continent: Should match Unity Editor snap settings")]
    [SerializeField] int unityGridSize = 10;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    //Property definition 
    public int UnityGridSize { get { return UnityGridSize; } }

    //Property for accessing
    public Dictionary<Vector2Int,Node> Grid { get { return grid; } }

    //Unity is awakened
    void Awake()
    {
        CreateGrid();
    }

    //To get Node info from outside
    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        return null;
    }
    
    //to create the grid for movement
    private void CreateGrid()
    {
        for(int x =0; x< gridSize.x;++x)
            for(int y= 0; y < gridSize.y; ++y)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates,new Node(coordinates, true));
                Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isWalkable);
            }
    }

    //To check where enemy can walk
    public void BlockedNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }

    }

    //To get the coodinates of the position
    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    //To get the position from the coordinates
    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }
}
