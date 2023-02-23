using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Strenght of enemy unit")][SerializeField] int maxHitPoint = 5;
    private int currentHitPoints = 0;

    // Whenever object enabled/disabled
    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    //To process the collision
    void OnParticleCollision(GameObject other)      //make sure to enable 'Send collision message'
    {
        //GameObject vFx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        //vFx.transform.parent = parentGameObject.transform;
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
    }
}
