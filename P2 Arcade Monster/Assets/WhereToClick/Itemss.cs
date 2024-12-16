using UnityEngine;

public class Itemss : MonoBehaviour
{
    public enum ItemType { Fruit, Veggie, Tomato }
    public ItemType itemType;

    public GameManager gameManager;

    // Sprite arrays for fruits and veggies
    public Sprite[] fruitSpritesArray;    // Fruit sprite array
    public Sprite[] veggieSpritesArray;   // Veggie sprite array

    // Sprite arrays for tomatoes
    public Sprite[] greenTomatoSpritesArray;  // Green tomato sprite array
    public Sprite[] redTomatoSpritesArray;    // Red tomato sprite array

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the GameManager reference
        gameManager = FindObjectOfType<GameManager>();

        // Get the SpriteRenderer component to change the sprite dynamically
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Assign a random sprite based on item type
        if (itemType == ItemType.Fruit)
        {
            spriteRenderer.sprite = fruitSpritesArray[Random.Range(0, fruitSpritesArray.Length)];
        }
        else if (itemType == ItemType.Veggie)
        {
            spriteRenderer.sprite = veggieSpritesArray[Random.Range(0, veggieSpritesArray.Length)];
        }
        else if (itemType == ItemType.Tomato)
        {
            // Assign random sprite for Green or Red Tomato based on its tag
            if (gameObject.CompareTag("GreenTomatoPrefab"))
            {
                spriteRenderer.sprite = greenTomatoSpritesArray[Random.Range(0, greenTomatoSpritesArray.Length)];
            }
            else if (gameObject.CompareTag("RedTomatoPrefab"))
            {
                spriteRenderer.sprite = redTomatoSpritesArray[Random.Range(0, redTomatoSpritesArray.Length)];
            }
        }
    }

    void OnMouseDown()
    {
        // Check for mouse button press and item type
        if (itemType == ItemType.Veggie)
        {
            // Left click on veggie goes to veggie box (correct)
            if (Input.GetMouseButtonDown(0))  // Left click
            {
                gameManager.UpdateScore(); // Correct placement for Veggies
                Destroy(gameObject); // Destroy the object after clicking it correctly
            }
            // Right click on veggie goes to fruit box (incorrect)
            else if (Input.GetMouseButtonDown(1))  // Right click
            {
                gameManager.AddStrike();  // Incorrect placement
                Destroy(gameObject); // Destroy object after wrong click
            }
        }
        else if (itemType == ItemType.Fruit)
        {
            // Left click on fruit goes to veggie box (incorrect)
            if (Input.GetMouseButtonDown(0))  // Left click
            {
                gameManager.AddStrike();  // Incorrect placement
                Destroy(gameObject); // Destroy object after wrong click
            }
            // Right click on fruit goes to fruit box (correct)
            else if (Input.GetMouseButtonDown(1))  // Right click
            {
                gameManager.UpdateScore(); // Correct placement
                Destroy(gameObject); // Destroy object after correct click
            }
        }
        else if (itemType == ItemType.Tomato)
        {
            // Both left and right clicks work on tomatoes
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))  // Left or right click
            {
                if (gameObject.CompareTag("RedTomatoPrefab"))
                {
                    gameManager.RestoreStrike(); // Red tomato restores 1 strike
                }
                else if (gameObject.CompareTag("GreenTomatoPrefab"))
                {
                    gameManager.AddTime(10); // Green tomato adds 10 seconds
                }

                Destroy(gameObject); // Destroy the tomato after clicking it
            }
        }
    }
}
