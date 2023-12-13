using UnityEngine;

public class CandyCaneSwing : MonoBehaviour
{
    public float swingForce = 500f; // Force applied when swinging the weapon
    public string targetTag = "Enemy"; // Tag of objects that the weapon can hit

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            SwingWeapon();
        }
    }

    void SwingWeapon()
    {
        // Apply a force to the weapon when swinging
        Rigidbody weaponRb = GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            weaponRb.AddForce(transform.forward * swingForce);
        }
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the specified tag (e.g., Enemy)
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Handle the collision with the enemy here
            Debug.Log("Enemy Hit!");
            // You can add code here to damage the enemy or perform any other action
        }
        else if (collision.gameObject.GetComponent<CandyCaneSwing>() != null)
        {
            // Handle the collision with the CandyCaneClub here
            Debug.Log("CandyCaneClub Hit!");
            // You can add code here to perform any action when the CandyCaneClub is hit
        }
    }
}