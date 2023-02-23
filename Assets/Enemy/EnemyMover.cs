using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [Tooltip("To delay the movement")][SerializeField] float waitTime = 1f;
    
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

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(startPositon, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
