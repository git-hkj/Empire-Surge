using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    //Constructor
    public Node(Vector2Int coordinates, bool isWalk)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalk;
    }


}