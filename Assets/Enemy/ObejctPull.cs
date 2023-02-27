using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the script's name a typo, it should be 'Object Pool' instead

public class ObejctPull : MonoBehaviour
{
    [Tooltip("To define enemy type")][SerializeField] GameObject enemyPrefab;
    [Tooltip("Size of the pool for each waves")][SerializeField][Range(1f, 20f)] int poolSize=4;
    [Tooltip("Time for Enemy respawn")][SerializeField] [Range(0.1f,30f)] float spawnTimer = 1f;

    GameObject[] pool;

    //Unity is awakened
    void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    //To populate the pool with object as per requirement
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    //To control the enemy spawn
    IEnumerator CreateEnemy()
    {
        while (true)
        {
            EnabledObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    //To enable the enemy in the pool
    void EnabledObjectInPool()
    {
        for(int i=0; i<poolSize;++i)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
