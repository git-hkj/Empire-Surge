using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [Tooltip("The weapon to fire")][SerializeField] Transform weapon;
    [Tooltip("Range of tower fire")][SerializeField] float towerRange = 15f;
    [Tooltip("Projectiles used for attacking")] [SerializeField] ParticleSystem projectiles;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    //To find the closest enemy to attack
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy aVar in enemies)
        {
            //find distance b/w enemy and tower
            float targetDistance = Vector3.Distance(transform.position, aVar.transform.position);

            //comparing the distances
            if (targetDistance < maxDistance)
            {
                closestTarget = aVar.transform;
                maxDistance = targetDistance; //reducing maxDistance
            }
        }

        target = closestTarget; //the closest one found
    }

    //to aim at the enemy during its movement
    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        //to check if the enemy is in range
        if (targetDistance < towerRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    //To control the particle system during firing
    void Attack(bool isActive)
    {
        var emissionModule = projectiles.emission;
        emissionModule.enabled = isActive;
    }
}
