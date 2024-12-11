using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] initialTargetPrefabs; // Array of prefabs to use initially
    public GameObject[] changedTargetPrefabs; // Array of prefabs to use after 40 seconds
    public float spawnInterval = 2f;
    public int maxTargets = 5;

    private GameObject[] currentTargetPrefabs; // Current array of target prefabs
    private float timer;

    public void Start()
    {
        currentTargetPrefabs = initialTargetPrefabs; // Start with the initial array
        StartCoroutine(SwitchToChangedPrefabs(15f)); // Switch after 40 seconds
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && GameObject.FindGameObjectsWithTag("Target").Length < maxTargets)
        {
            SpawnTarget();
            timer = 0;
        }
    }

    void SpawnTarget()
    {
        // Randomly pick a prefab from the current array
        GameObject targetPrefab = currentTargetPrefabs[Random.Range(0, currentTargetPrefabs.Length)];
        Instantiate(targetPrefab, GetRandomPosition(), Quaternion.identity);
    }

    Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f)); // Adjust for your game area
    }

    IEnumerator SwitchToChangedPrefabs(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentTargetPrefabs = changedTargetPrefabs; // Switch to the second array
    }
}
