using System.Collections;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwForce = 1000f; // Adjust the throwForce value to your liking
    public float respawnDelay = 3f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 offset = new Vector3(1f, -0.5f, 1f); // Adjust the offset for Snowball visibility

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        SpawnNewSnowball(); // Initial snowball spawn
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Entered trigger with enemy");

            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                Debug.Log("EnemyHealth component found");
                enemyHealth.TakeDamage(10);
            }
            else
            {
                Debug.LogWarning("EnemyHealth component not found.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Exited trigger with enemy");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (pickedup)
                {
                    ThrowObject();
                }
                else
                {
                    PickUpObject();
                }
            }
        }

        if (pickedup)
        {
            // Continuously update the Snowball's position to follow the player with an offset
            objTransform.position = cameraTrans.position + cameraTrans.TransformDirection(offset);
        }
    }

    void PickUpObject()
    {
        objTransform.parent = cameraTrans;
        objRigidbody.useGravity = false;
        objRigidbody.velocity = Vector3.zero; // Zero out velocity
        objRigidbody.angularVelocity = Vector3.zero; // Zero out angular velocity
        pickedup = true;
    }

    void DropObject()
    {
        objTransform.parent = null;
        objRigidbody.useGravity = true;
        pickedup = false;
    }

    void ThrowObject()
    {
        DropObject();
        objRigidbody.velocity = Vector3.zero; // Zero out velocity
        objRigidbody.angularVelocity = Vector3.zero; // Zero out angular velocity
        objRigidbody.AddForce(cameraTrans.forward * throwForce, ForceMode.Impulse);

        // Optional: Invoke a method to reset the snowball after a delay (respawnDelay seconds)
        Invoke("SpawnNewSnowball", respawnDelay);
    }

    void SpawnNewSnowball()
    {
        // Reactivate the disabled snowball
        objTransform.gameObject.SetActive(true);

        // Reset position and rotation
        objTransform.position = initialPosition;
        objTransform.rotation = initialRotation;

        // Pick up the new snowball
        PickUpObject();
    }
}