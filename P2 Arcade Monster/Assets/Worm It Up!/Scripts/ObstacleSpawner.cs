using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  //  Obstacle prefab
    public float spawnInterval = 3f;   // Interval between spawns
    public float fallSpeed;       // How fast the obstacles fall

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);  

    void SpawnObstacle()
        {
            float xPos = Random.Range(-7f, 7f);
            Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0);  // Use y position from spawner


            GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);


            SpriteRenderer obstacleRenderer = obstacle.GetComponent<SpriteRenderer>();
            obstacleRenderer.color = Color.red;

            // Add Rigidbody2D 
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = obstacle.AddComponent<Rigidbody2D>();
            }


            rb.gravityScale = 1f;  

        }
    }
}
