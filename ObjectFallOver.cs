using UnityEngine;

public class ObjectFallOver : MonoBehaviour
{
    public float fallForce = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply a force to make the object fall over
                rb.AddForce(Vector3.forward * fallForce, ForceMode.Impulse);
            }
        }
    }
}