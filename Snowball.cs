// Snowball.cs
using UnityEngine;

public class Snowball : MonoBehaviour, IThrowable
{
    public int damage = 10; // Adjust the damage value as needed
    private Rigidbody snowballRigidbody;

    void Start()
    {
        snowballRigidbody = GetComponent<Rigidbody>();
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public void Throw(Vector3 direction, float force)
    {
        // Ensure the snowball has a Rigidbody component
        if (snowballRigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the snowball.");
            return;
        }

        // Activate the snowball (in case it was deactivated)
        gameObject.SetActive(true);

        // Apply force to the snowball in the specified direction
        snowballRigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}