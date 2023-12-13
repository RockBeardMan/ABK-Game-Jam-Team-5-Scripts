// ThrowScript.cs
using UnityEngine;

public class ExampleThrowScript : MonoBehaviour
{
    public GameObject snowballPrefab;
    public Transform throwPoint;
    public float throwForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowSnowball();
        }
    }

    void ThrowSnowball()
    {
        // Instantiate a snowball
        GameObject snowballObject = Instantiate(snowballPrefab, throwPoint.position, throwPoint.rotation);

        // Get the IThrowable component from the snowball
        IThrowable throwable = snowballObject.GetComponent<IThrowable>();

        if (throwable != null)
        {
            // Set damage (optional)
            throwable.SetDamage(20);

            // Throw the snowball using the IThrowable interface
            throwable.Throw(throwPoint.forward, throwForce);
        }
    }
}