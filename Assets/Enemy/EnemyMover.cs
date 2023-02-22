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
            transform.position = a.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
