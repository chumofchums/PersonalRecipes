using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{

    public GameObject projectilePrefab;
    public GameObject shootFromTransform;
    public float towerFireRate = 1f;
    public float towerRange = 10f;
    public int towerDamage = 1;

    private Transform target;
    private float fireCountdown = 0f;

    void Update()
    {
        if (fireCountdown > 0f)
        {
            fireCountdown -= Time.deltaTime;
        }
        else
        {
            FindTarget();
            if (target != null)
            {
                Shoot();
                fireCountdown = 1f / towerFireRate;
            }
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        if (closestDistance <= towerRange)
        {
            target = closestEnemy;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, shootFromTransform.transform.position, Quaternion.identity);
        ProjectileBehavior projectile = projectileObject.GetComponent<ProjectileBehavior>();

        if (projectile != null && target != null)
        {
            projectile.SetTarget(target);
            projectile.damage = towerDamage;
        }
    }
}
