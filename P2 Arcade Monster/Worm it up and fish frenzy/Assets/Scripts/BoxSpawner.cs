using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;  // Reference to the Box prefab
    public float spawnInterval = 3f;  // Interval between spawns
    public float fallSpeed = 3f;  // How fast the boxes fall
    public float boxSpacing = 1.5f;  // Spacing between each box when spawning in a line

    void Start()
    {
        InvokeRepeating("SpawnBox", 0f, spawnInterval);
    }

    void SpawnBox()
    {
        int numberOfBoxes = Random.Range(1, 4);  // Randomly choose to spawn 1, 2, or 3 boxes
        float xPos = Random.Range(-7f, 7f);  // Random x position for the first box

        // Loop to spawn the chosen number of boxes in a line
        for (int i = 0; i < numberOfBoxes; i++)
        {
            // Adjusting spawn position based on index to create a line (in the y-direction)
            Vector3 spawnPos = new Vector3(xPos, transform.position.y - (i * boxSpacing), 0);

            GameObject box = Instantiate(boxPrefab, spawnPos, Quaternion.identity);

            // Set the color of the box using a switch statement
            SpriteRenderer boxRenderer = box.GetComponent<SpriteRenderer>();
            Color boxColor = GetBoxColor();  // Get the box color from the method
            boxRenderer.color = boxColor;

            // Add Rigidbody2D to make the box fall (if not already attached)
            Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = box.AddComponent<Rigidbody2D>();
            }

            // Set gravity scale or any other physics properties if needed
            rb.gravityScale = 1f;  // Default gravity scale
        }
    }

    // Method to return a random color using a switch statement
    Color GetBoxColor()
    {
        int randomColor = Random.Range(0, 3);  // 0 = Red, 1 = Blue, 2 = Green

        switch (randomColor)
        {
            case 0:
                return Color.red;  // Red
            case 1:
                return Color.blue;  // Blue
            case 2:
                return Color.green;  // Green
            default:
                return Color.white;  // Default color
        }
    }
}
