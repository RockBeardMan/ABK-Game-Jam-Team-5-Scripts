using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float stoppingDistance = 1f;
    private GameObject player;

    void Start()
    {
        // Find the player game object based on its tag
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player GameObject not found with tag 'Player'!");
        }
        else
        {
            Debug.Log("Player GameObject found with tag 'Player'");
        }
    }

    void FixedUpdate()
    {
        // Calculate the direction towards the player based on their current position
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0;

            // Update the movement direction if the player is moving
            if (directionToPlayer.magnitude > stoppingDistance)
            {
                Vector3 movementDirection = directionToPlayer.normalized;

                // Move the game object in the current movement direction
                GetComponent<Rigidbody>().velocity = movementDirection * movementSpeed;
            }
            else
            {
                // Stop moving if the player is within the stopping distance
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}