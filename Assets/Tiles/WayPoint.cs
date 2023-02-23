using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    //To know when mouse button are clicked
    void OnMouseDown()
    {
        if (isPlaceable) 
        { 
            //if(Input.GetMouseButtonDown(0)) for OnMouseOver()
            Debug.Log(transform.name);
        }
    }
}
