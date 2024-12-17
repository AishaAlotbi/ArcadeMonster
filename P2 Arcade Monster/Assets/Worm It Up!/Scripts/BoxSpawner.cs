using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;  //  Box prefab
    public float spawnInterval = 3f;  // Interval between spawns
    public float fallSpeed;  // How fast the boxes fall
    public float boxSpacing = 1.5f;  

    void Start()
    {
        InvokeRepeating("SpawnBox", 0f, spawnInterval);
    }

    void SpawnBox()
    {
        int numberOfBoxes = Random.Range(1, 4);  
        float xPos = Random.Range(-7f, 7f);  

        // Loop 
        for (int i = 0; i < numberOfBoxes; i++)
        {
            
            Vector3 spawnPos = new Vector3(xPos, transform.position.y - (i * boxSpacing), 0);

            GameObject box = Instantiate(boxPrefab, spawnPos, Quaternion.identity);

            
            SpriteRenderer boxRenderer = box.GetComponent<SpriteRenderer>();
            Color boxColor = GetBoxColor();  
            boxRenderer.color = boxColor;

            // Add Rigidbody2D 
            Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = box.AddComponent<Rigidbody2D>();
            }

            
            rb.gravityScale = 1f;  
        }
    }

    
    Color GetBoxColor()
    {
        int randomColor = Random.Range(0, 3);  // 0 = Red, 1 = Blue, 2 = Green

        switch (randomColor)
        {
            case 0:
                return Color.red;  
            case 1:
                return Color.blue;
            case 2:
                return Color.green;  
            default:
                return Color.white;  
        }
    }
}
