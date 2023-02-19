using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 1;

    private Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                EnemyBehavior enemy = target.gameObject.GetComponent<EnemyBehavior>();

                if (enemy != null)
                {
                    enemy.enemyHealth -= damage;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetTarget(Transform enemyTransform)
    {
        target = enemyTransform;
    }
}
