using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private float enemySpeed = 2f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Tower").transform;
    }

    void Update()
    {
        // Calculate direction towards target
        Vector3 direction = target.position - transform.position;

        // Normalize direction to get unit vector
        direction.Normalize();

        // Move towards target at speed
        transform.position += direction * enemySpeed * Time.deltaTime;
    }
}
