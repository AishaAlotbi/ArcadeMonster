using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs
    public float spawnInterval = 2f; // Time  spawns
    private float timeSinceLastSpawn = 0f;
    public float dropSpeed = 2f; // falling speed 

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnItem();
            timeSinceLastSpawn = 0f;

            //  increase spawn speed and drop speed
            spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.01f);
            dropSpeed += 0.1f; 
        }
    }

    void SpawnItem()
    {
        if (itemPrefabs == null || itemPrefabs.Length == 0)
        {
            
            return;
        }

        int index = Random.Range(0, itemPrefabs.Length);

        if (itemPrefabs[index] != null)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f); //top screeeen
            GameObject newItem = Instantiate(itemPrefabs[index], spawnPosition, Quaternion.identity);

            // falling speed 
            Rigidbody2D rb = newItem.AddComponent<Rigidbody2D>();
            rb.gravityScale = dropSpeed; 
        }
        
    }
}
