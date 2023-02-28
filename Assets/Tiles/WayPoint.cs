using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [Tooltip("To define where defense can be placed")][SerializeField] bool isPlaceable;
    //defining a property to make the bool more accessable 
    public bool IsPlaceable { get { return isPlaceable; } }
    
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
