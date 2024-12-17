using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;  //  PowerUp prefab
    public float spawnInterval = 3f;  // Interval between spawns
    public float fallSpeed;  

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 0f, spawnInterval);  
    }

    void SpawnPowerUp()
    {
        float xPos = Random.Range(-7f, 7f);  // Random x position within the screen
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0);  // Use y position from spawner

        
        GameObject powerUp = Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);

        
        SpriteRenderer powerUpRenderer = powerUp.GetComponent<SpriteRenderer>();
        powerUpRenderer.color = Color.yellow;  

       //rigif bidy
        Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = powerUp.AddComponent<Rigidbody2D>();
        }

        
        rb.gravityScale = 1f;  

        
    }
}
