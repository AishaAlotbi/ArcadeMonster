using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the worm
    private Vector2 movement;  // Player movement vector

    public int lengthInCm = 0;  // Track the length in cmy
    public int health = 2;  // Default HP for the worm
    public Text lengthText;  // Reference to the UI Text for displaying length
    public Text healthText;  // Reference to the UI Text for displaying HP
    public PlayerController self;
    public SpriteRenderer selfRender;

    void Update()
    {
        // Player movement (left-right on a fixed axis)
        movement.x = Input.GetAxis("Horizontal");
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Update the UI text with the current length in cm
        if (lengthText != null)
        {
            lengthText.text = "Length: " + lengthInCm + " cm";
        }

        // Update the UI text with the current health
        if (healthText != null)
        {
            healthText.text = "HP: " + health;  // Display the current health
        }

    }

    // Method to increase length when the player eats a box
    public void IncreaseLength(int cm)
    {
        lengthInCm += cm;  // Increase the length
    }
}
