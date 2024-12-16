using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;  // Reference to PlayerController script

    void Start()
    {
        // Get the PlayerController script attached to the player
        playerController = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            // Increase the player's length by 10 cm when they eat a box
            playerController.IncreaseLength(10);

            // Destroy the box after eating it
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Reduce health by 1 when colliding with an obstacle
            playerController.health--;  // Access health from PlayerController script
            Destroy(other.gameObject);  // Destroy obstacle after hit

            // Check if health reaches 0
            if (playerController.health <= 0)
            {
                // Game Over logic
                Debug.Log("Game Over!");
                // Switch to Game Over scene
                SceneManager.LoadScene("GameOver"); // This will switch to the scene named "GameOver"
            }
        }
        else if (other.CompareTag("PowerUp"))
        {
            // Increase the player's health by 1 when they eat a power-up
            playerController.health++;

            // Destroy the power-up after it is eaten
            Destroy(other.gameObject);
        }
    }
}
