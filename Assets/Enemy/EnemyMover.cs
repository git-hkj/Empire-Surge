using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [Tooltip("To define how fast enemy moves")][SerializeField] [Range(0f,5f)]float enemySpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        }

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
    }
}
