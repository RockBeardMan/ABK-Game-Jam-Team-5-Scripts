using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public string krampusTag = "Krampus";  // Tag for the Krampus GameObject
    public TMP_Text gameOverText;  // Reference to the TMP Text element

    void Update()
    {
        // Add a debug message to check if the Update method is being called
        Debug.Log("Update method called.");

        // Find the GameObject with the specified tag
        GameObject krampus = GameObject.FindGameObjectWithTag(krampusTag);

        if (krampus == null)
        {
            // The Krampus is defeated
            Debug.Log("Krampus is defeated. Showing game over text.");
            ShowGameOverText();
        }
    }

    void ShowGameOverText()
    {
        // Set the text to display on the TMP Text element
        gameOverText.text = "Game Over - You Win!";
        // Additional UI logic can be added here

        // Add a debug message to check if ShowGameOverText method is being called
        Debug.Log("ShowGameOverText method called.");
    }
}