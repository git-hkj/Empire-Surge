using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [Tooltip("To define how path for enemy")][SerializeField] List<WayPoint> path = new List<WayPoint>();
    [Tooltip("To define how fast enemy moves")][SerializeField] [Range(0f,5f)]float enemySpeed = 1f;

    Enemy enemy;

    // Whenever object enabled/disabled
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    //To be able to find a path using the tag
    void FindPath()
    {
        path.Clear(); //to clear existing path 
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform aVar in parent.transform)
        {
            WayPoint waypoint = aVar.GetComponent<WayPoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
            
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

        FinishPath();
    }

    //To define the end of path and make player pay fine
    private void FinishPath()
    {
        enemy.PayFine();
        gameObject.SetActive(false);
    }
}
