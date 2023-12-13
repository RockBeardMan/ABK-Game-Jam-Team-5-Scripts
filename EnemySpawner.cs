using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EvilElf;         // Prefab of the enemy to spawn
    public GameObject snowballPrefab;  // Prefab of the snowball
    public float spawnInterval = 0.5f;   // Time between enemy spawns
    public int maxEnemies = 300;       // Maximum number of enemies to spawn
    public float enemySpeed = 5f;      // Movement speed of enemies

    private bool isSpawning = true;   // Flag to control whether the spawner should continue spawning
    private int spawnedEnemies = 0;     // Counter for spawned enemies

    void Start()
    {
        // Start spawning enemies when the script starts
        StartSpawning();
    }

    void OnDestroy()
    {
        // The spawner is being destroyed, stop spawning
        isSpawning = false;
    }

    void StartSpawning()
    {
        // Set isSpawning to true to start spawning enemies
        isSpawning = true;

        // Start spawning enemies repeatedly
        StartCoroutine(SpawnEnemies());
    }

    void SpawnSnowball()
    {
        // Instantiate the snowball
        GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);

        // Attach a script or logic to the snowball if needed
        // For example, you might have a script that handles snowball interactions
    }

    IEnumerator SpawnEnemies()
    {
        while (isSpawning && spawnedEnemies < maxEnemies)
        {
            // Find the player object
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            // Check if the player is found
            if (player != null)
            {
                // Use the player's Y-position as the spawn position
                Vector3 spawnPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

                // Instantiate the enemy at the valid position
                GameObject newEnemy = Instantiate(EvilElf, spawnPosition, Quaternion.identity);

                // Check if the new enemy is not null before accessing or destroying it
                if (newEnemy != null)
                {
                    Debug.Log("Enemy spawned. Total enemies: " + (++spawnedEnemies));

                    // Add any additional setup or logic with the new enemy here
                    // For example, you can set the spawner as the parent of the new enemy
                    newEnemy.transform.parent = transform;

                    // Ensure the enemy is upright
                    SetUpright(newEnemy.transform);

                    // Start tracking the player
                    StartCoroutine(TrackPlayer(newEnemy.transform));
                }
                else
                {
                    Debug.LogWarning("Failed to instantiate enemy.");
                }
            }
            else
            {
                Debug.LogWarning("Player not found.");
            }

            // Wait for a fixed time interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SetUpright(Transform enemyTransform)
    {
        // Set the enemy's rotation to be upright
        enemyTransform.rotation = Quaternion.identity;
    }

    IEnumerator TrackPlayer(Transform enemyTransform)
    {
        // Replace "Player" with the tag you have assigned to the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        while (player != null)
        {
            // Check if the player's Transform is not null before attempting to use it
            if (player.transform != null)
            {
                // Calculate the direction to the player
                Vector3 directionToPlayer = (player.transform.position - enemyTransform.position).normalized;

                // Move towards the player on the XZ plane without changing the Y position
                enemyTransform.position += new Vector3(directionToPlayer.x, 0, directionToPlayer.z) * enemySpeed * Time.deltaTime;
            }
            else
            {
                // Player has been destroyed, exit the coroutine
                yield break;
            }

            yield return null;
        }
    }
}