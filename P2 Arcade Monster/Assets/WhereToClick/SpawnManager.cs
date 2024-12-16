using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs
    public float spawnInterval = 2f; // Time interval between spawns
    private float timeSinceLastSpawn = 0f;
    public float dropSpeed = 2f; // Initial falling speed for items

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnItem();
            timeSinceLastSpawn = 0f;

            // Gradually increase spawn speed and drop speed
            spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.01f);
            dropSpeed += 0.1f; // Increase drop speed over time
        }
    }

    void SpawnItem()
    {
        if (itemPrefabs == null || itemPrefabs.Length == 0)
        {
            Debug.LogError("Item prefabs array is empty or not assigned. Please assign prefabs in the inspector.");
            return;
        }

        int index = Random.Range(0, itemPrefabs.Length);

        if (itemPrefabs[index] != null)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f); // Spawn at top of screen
            GameObject newItem = Instantiate(itemPrefabs[index], spawnPosition, Quaternion.identity);

            // Add falling speed to the spawned item
            Rigidbody2D rb = newItem.AddComponent<Rigidbody2D>();
            rb.gravityScale = dropSpeed; // Adjust the fall speed
        }
        else
        {
            Debug.LogWarning("Prefab at index " + index + " is null. Please ensure all elements in the itemPrefabs array are assigned.");
        }
    }
}
