using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Tooltip("To define where defense can be placed")][SerializeField] bool isPlaceable;
    [SerializeField] private GameObject towerPrefab;

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
