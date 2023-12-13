using UnityEngine;

public class CandyCaneControl : MonoBehaviour
{
    public float swingForce = 500f; // Adjust the force applied when swinging
    public int damageAmount = 10;  // Damage amount to deal

    private Rigidbody caneRigidbody;

    void Start()
    {
        // Get the Rigidbody component of the CandyCane
        caneRigidbody = GetComponent<Rigidbody>();

        if (caneRigidbody == null)
        {
            Debug.LogError("Rigidbody not found on CandyCane!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            SwingCane();
        }
    }

    void SwingCane()
    {
        // Check if the Rigidbody is found
        if (caneRigidbody != null)
        {
            // Apply a torque force to make the CandyCane swing
            caneRigidbody.AddTorque(Vector3.right * swingForce);

            // Check for enemies in front of the cane using a raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Check if the hit object has an EnemyHealth component
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    // Deal damage to the enemy
                    enemyHealth.TakeDamage(damageAmount);
                }
            }
        }
    }
}