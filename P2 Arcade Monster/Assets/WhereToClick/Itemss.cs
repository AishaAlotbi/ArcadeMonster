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
       
        gameManager = FindObjectOfType<GameManager>();

        //  SpriteRenderer component 
        spriteRenderer = GetComponent<SpriteRenderer>();

        // A random sprite 
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
        // Check  mouse button 
        if (itemType == ItemType.Veggie)
        {
            // Left click 
            if (Input.GetMouseButtonDown(0))  
            {
                gameManager.UpdateScore(); 
                Destroy(gameObject); // Destroy the object 
            }
            // Right click 
            else if (Input.GetMouseButtonDown(1))  
            {
                gameManager.AddStrike();  
                Destroy(gameObject); // Destroy object 
            }
        }
        else if (itemType == ItemType.Fruit)
        {
            // Left click 
            if (Input.GetMouseButtonDown(0))  
            {
                gameManager.AddStrike();  
                Destroy(gameObject); // Destroy object 
            }
            // Right click 
            else if (Input.GetMouseButtonDown(1))  
            {
                gameManager.UpdateScore();
                Destroy(gameObject); // Destroy 
            }
        }
        else if (itemType == ItemType.Tomato)
        {
            //  left and right clicks 
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))  
            {
                if (gameObject.CompareTag("RedTomatoPrefab"))
                {
                    gameManager.RestoreStrike(); // Red tomato restores 1 strike
                }
                else if (gameObject.CompareTag("GreenTomatoPrefab"))
                {
                    gameManager.AddTime(10); // Green tomato adds 10 seconds
                }

                Destroy(gameObject); // Destroy the tomato 
            }
        }
    }
}
