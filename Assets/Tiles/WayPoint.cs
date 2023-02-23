using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [Tooltip("To define where defense can be placed")][SerializeField] bool isPlaceable;
    //defining a property to make the bool more accessable 
    public bool IsPlaceable { get { return isPlaceable; } }
    
    //To perform action when mouse button are clicked
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false; //to make sure one tower per grid point
        }
    }
}
