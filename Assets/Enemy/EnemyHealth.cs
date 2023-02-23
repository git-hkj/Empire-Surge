using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Strenght of enemy unit")][SerializeField] int maxHitPoint = 5;
    private int currentHitPoints = 0;

    Enemy enemy;

    // Whenever object enabled/disabled
    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    //To process the collision
    void OnParticleCollision(GameObject other)      //make sure to enable 'Send collision message'
    {
        ProcessHit(other);
        if (currentHitPoints < 1)
        {
            KillEnemy();
        }
    }

    //To process the hit 
    void ProcessHit(GameObject other)
    {
        currentHitPoints--;
    }

    //To process destruction of the enemy and track scores
    void KillEnemy()
    {
        gameObject.SetActive(false);
        enemy.RewardGold();
    }
}
