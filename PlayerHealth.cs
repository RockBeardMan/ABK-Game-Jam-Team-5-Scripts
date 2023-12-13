using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;  // Set the maximum health value
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

        // Check if the player has run out of health
        if (currentHealth <= 0)
        {
            // Call a method to handle the player's death (e.g., respawn)
            Die();
        }
    }

    // Method to handle the player's death
    void Die()
    {
        // You can add any death-related logic here, such as respawning the player
        Debug.Log("Player died!");
        Respawn();
    }

    // Method to respawn the player
    void Respawn()
    {
        // Add any logic here to reset the player's position, health, etc.
        currentHealth = maxHealth;
        transform.position = Vector3.zero; // Reset position to a default location
    }
}