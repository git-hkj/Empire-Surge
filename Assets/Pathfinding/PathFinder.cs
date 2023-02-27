using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Node currentNode;
    private Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    //Unity is awakened
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ExploreNeighbor();
    }

    //to explore the neighbors of the current node
    private void ExploreNeighbor()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int aVar  in directions)
        {
           Vector2Int neighborCoordinates = currentNode.coordinates + aVar;

           if (grid.ContainsKey(neighborCoordinates))
           {
                neighbors.Add(grid[neighborCoordinates]);

                //TODO: remove after testing
                grid[neighborCoordinates].isExplored=true;
                grid[currentNode.coordinates].isPath=true;
           }
        }
    }
}
