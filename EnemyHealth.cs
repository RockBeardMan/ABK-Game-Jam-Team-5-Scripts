using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Set the maximum health value
    private int currentHealth;   // Current health

    void Start()
    {
        // Set initial health to maxHealth
        currentHealth = maxHealth;
    }

    // Method to decrease health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // If health is zero or below, despawn the object
            Despawn();
        }
    }

    // Method to despawn the object
    void Despawn()
    {
        Debug.Log("Enemy despawned!");
        // Add any additional cleanup or despawning logic here
        Destroy(gameObject);
    }
}