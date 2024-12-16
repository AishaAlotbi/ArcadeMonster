using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Reference to the Obstacle prefab
    public float spawnInterval = 3f;   // Interval between spawns
    public float fallSpeed;       // How fast the obstacles fall

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);  // Start spawning obstacles at the given interval
    }

    void SpawnObstacle()
    {
        float xPos = Random.Range(-7f, 7f);  // Random x position within the screen
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0);  // Use y position from spawner

        // Instantiate the obstacle at the calculated position
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        // Set the color of the obstacle to red (R = 1, G = 0, B = 0)
        SpriteRenderer obstacleRenderer = obstacle.GetComponent<SpriteRenderer>();
        obstacleRenderer.color = Color.red;  // Always set the color to red

        // Add Rigidbody2D to make the obstacle fall (if not already attached)
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = obstacle.AddComponent<Rigidbody2D>();
        }

        // Set gravity scale or any other physics properties if needed
        rb.gravityScale = 1f;  // Default gravity (you can tweak this to control the fall speed)

        // You can add more behavior here, like setting obstacle properties (e.g., type of obstacle)
    }
}
