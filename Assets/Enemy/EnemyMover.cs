using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("To define how path for enemy")][SerializeField] List<WayPoint> path = new List<WayPoint>();
    [Tooltip("To define how fast enemy moves")][SerializeField] [Range(0f,5f)]float enemySpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        StartCoroutine(FollowPath());
    }

    //To be able to find a path using the tag
    void FindPath()
    {
        path.Clear(); //to clear existing path 
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject aVar in waypoints)
        {
            path.Add(aVar.GetComponent<WayPoint>());
        }
    }

    //Move the enemy back into first waypoint
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    //To define a path for enemy to follow
    IEnumerator FollowPath()
    {
        foreach (WayPoint a in path)
        {
            Vector3 startPositon = transform.position;
            Vector3 endPosition  = a.transform.position;
            float travelPercent  = 0f;

            transform.LookAt(endPosition);      //to always look at the endposition

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPositon, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }
}
