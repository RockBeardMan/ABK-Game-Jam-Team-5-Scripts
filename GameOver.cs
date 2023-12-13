using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject golem;  // Reference to the golem object (or any other boss/enemy you want to track)

    void Update()
    {
        // Check if the golem is null, indicating it is destroyed
        if (golem == null)
        {
            Debug.Log("Game Over - You Win!");
            // Add any additional game over logic here

            // For example, you might load a new scene or display a game over UI
        }
    }
}