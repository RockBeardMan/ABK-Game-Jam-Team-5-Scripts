using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float openAngle = 90.0f;
    public GameObject doorObject; // Assign the door object in the Inspector
    public Collider triggerVolume;

    private bool isOpening = false;

    private Quaternion initialRotation;

    void Start()
    {
        if (doorObject == null)
        {
            Debug.LogError("Door Object is not assigned in the inspector!");
        }

        // Store the initial rotation of the door
        initialRotation = doorObject.transform.localRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && IsPlayerInsideTriggerVolume())
        {
            ToggleDoor();
        }
    }

    bool IsPlayerInsideTriggerVolume()
    {
        return triggerVolume != null && triggerVolume.bounds.Contains(transform.position);
    }

    void ToggleDoor()
    {
        isOpening = !isOpening;

        if (isOpening)
        {
            // Open instantly
            doorObject.transform.localRotation = initialRotation * Quaternion.Euler(0.0f, 0.0f, openAngle);
        }
        else
        {
            // Close instantly
            doorObject.transform.localRotation = initialRotation;
        }
    }
}