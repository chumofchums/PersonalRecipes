using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public int enemyHealth = 1;

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        // Add death animation or sound effects here
        Destroy(gameObject);
    }
}
