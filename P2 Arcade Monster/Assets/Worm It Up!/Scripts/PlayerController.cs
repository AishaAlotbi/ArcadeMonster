using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the worm
    private Vector2 movement;  

    public int lengthInCm = 0;  //  length in cm
    public int health = 2;  //  HP for the worm
    public Text lengthText;  // UI length
    public Text healthText;  // UI HP
    public PlayerController self;
    public SpriteRenderer selfRender;

    void Update()
    {
        // Player movement 
        movement.x = Input.GetAxis("Horizontal");
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Lebgth UI
        if (lengthText != null)
        {
            lengthText.text = "Length: " + lengthInCm + " cm";
        }

        // UI Health
        if (healthText != null)
        {
            healthText.text = "HP: " + health;  
        }

    }

    // Length Increase
    public void IncreaseLength(int cm)
    {
        lengthInCm += cm;  
    }
}
