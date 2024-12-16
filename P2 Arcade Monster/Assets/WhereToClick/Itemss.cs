using UnityEngine;

public class Itemss : MonoBehaviour
{
    public enum ItemType { Fruit, Veggie, GreenTomato, RedTomato }
    public ItemType itemType;

    void OnMouseDown()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            if (itemType == ItemType.Veggie)
            {
                gameManager.UpdateScore();
                Destroy(gameObject);
            }
            else if (itemType == ItemType.Fruit)
            {
                gameManager.strikes++;
                Destroy(gameObject);
            }
        }
        else if (Input.GetMouseButtonDown(1)) // Right Click
        {
            if (itemType == ItemType.Fruit)
            {
                gameManager.UpdateScore();
                Destroy(gameObject);
            }
            else if (itemType == ItemType.GreenTomato)
            {
                gameManager.AddTime(10f);
                Destroy(gameObject);
            }
            else if (itemType == ItemType.RedTomato)
            {
                gameManager.RestoreStrike();
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        // Destroy item if it falls off-screen
        if (transform.position.y < -6f)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.missedItems++;
            Destroy(gameObject);
        }
    }
}
