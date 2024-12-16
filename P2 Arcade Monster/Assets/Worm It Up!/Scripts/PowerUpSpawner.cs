using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;  // Reference to the PowerUp prefab
    public float spawnInterval = 3f;  // Interval between spawns
    public float fallSpeed;  // How fast the power-ups fall

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 0f, spawnInterval);  // Start spawning power-ups at the given interval
    }

    void SpawnPowerUp()
    {
        float xPos = Random.Range(-7f, 7f);  // Random x position within the screen
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0);  // Use y position from spawner

        // Instantiate the power-up at the calculated position
        GameObject powerUp = Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);

        // Set the color of the power-up to yellow (R = 1, G = 1, B = 0)
        SpriteRenderer powerUpRenderer = powerUp.GetComponent<SpriteRenderer>();
        powerUpRenderer.color = Color.yellow;  // Always set the color to yellow

        // Add Rigidbody2D to make the power-up fall (if not already attached)
        Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = powerUp.AddComponent<Rigidbody2D>();
        }

        // Set gravity scale or any other physics properties if needed
        rb.gravityScale = 1f;  // Default gravity (you can tweak this to control the fall speed)

        // You can add more behavior here, like setting power-up properties (e.g., type of power-up)
    }
}
