using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [Tooltip("Enemy Gate")][SerializeField] Vector2Int startCoordinates;
    [Tooltip("King's Doorway")][SerializeField] Vector2Int destinationCoordiantes;

    Node startNode;
    Node destinationNode; 
    Node currentNode;

    Queue<Node> frontier =  new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

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
        startNode = gridManager.Grid[startCoordinates];
        destinationNode = gridManager.Grid[destinationCoordiantes]; ;
        BreadthFirstSearch();
        PathBuilder();
    }

    //to explore the neighbors of the current node
    void ExploreNeighbor()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int aVar  in directions)
        {
           Vector2Int neighborCoordinates = currentNode.coordinates + aVar;

           if (grid.ContainsKey(neighborCoordinates))
           {
                neighbors.Add(grid[neighborCoordinates]);
                
           }
        }

        foreach (Node aVar in neighbors)
        {
            if (!reached.ContainsKey(aVar.coordinates) && aVar.isWalkable)
            {
                aVar.connectedTo =currentNode;
                reached.Add(aVar.coordinates,aVar);
                frontier.Enqueue(aVar);
            }
        }
    }

    //To implement the breadth first search algorithm 
    void BreadthFirstSearch()
    {
        bool isRunning = true;
        
        frontier.Enqueue(startNode);
        reached.Add(startCoordinates,startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentNode = frontier.Dequeue();
            currentNode.isExplored  = true;
            ExploreNeighbor();
            if (currentNode.coordinates == destinationCoordiantes)
            {
                isRunning=false;
            }
        }
    }

    //To get the path from the search
    List<Node> PathBuilder()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            currentNode =  currentNode.connectedTo; //to move one step back the path
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse(); //to correct the order of the path

        return path;
    }
}
