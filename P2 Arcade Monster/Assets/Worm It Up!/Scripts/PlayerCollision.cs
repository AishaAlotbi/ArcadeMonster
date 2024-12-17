using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;  // Reference to PlayerController script

    void Start()
    {
       
        playerController = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            // Increase the player's length by 10 cm
            playerController.IncreaseLength(10);

            // Destroy the box 
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Reduce health by 1 
            playerController.health--;  
            Destroy(other.gameObject);  // Destroy obstacle 

            // Check if health reaches 0
            if (playerController.health <= 0)
            {
                // Game Over 
                Debug.Log("Game Over!");
                // Switch to Game Over scene
                SceneManager.LoadScene("GameOver"); // This will switch to the scene  "GameOver"
            }
        }
        else if (other.CompareTag("PowerUp"))
        {
            // Increase the player health by 1 
            playerController.health++;

            // Destroy PwrUP
            Destroy(other.gameObject);
        }
    }
}
