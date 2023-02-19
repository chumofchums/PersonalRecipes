using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // the prefab of the enemy object to spawn
    public Transform spawnPoint;   // the spawn point around which enemies will be spawned
    public float spawnRadius = 20f;  // the radius around the spawn point within which enemies will be spawned

    public int maxEnemies = 10;  // the maximum number of enemies to spawn at once
    private int numberOfEnemies = 0;  // the current number of enemies in the scene

    void Update()
    {
        // check if we need to spawn a new enemy
        if (numberOfEnemies < maxEnemies)
        {
            // generate a random position within the spawn radius
            Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
            randomPos.y = 0f;  // ensure the enemy is spawned at ground level

            // check if the random position is at least 10 units away from the spawn point
            if (Vector3.Distance(randomPos, spawnPoint.position) >= 10f)
            {
                // instantiate the enemy prefab at the random position and increment the enemy count
                Instantiate(enemyPrefab, randomPos, Quaternion.identity);
                numberOfEnemies++;
            }
        }
    }

    // called by the enemy object when it is destroyed
    public void OnEnemyDestroyed()
    {
        numberOfEnemies--;
    }
}
