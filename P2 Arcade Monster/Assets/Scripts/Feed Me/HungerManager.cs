using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    public float hunger = 500f; // Initial hunger value (0-100)
    public float hungerDecrease = 20f;
    public float hungerIncrease = 10f;
    public Slider hungerSlider; // UI slider to display hunger level
    public ItemPicker itemPicker; // Reference to the ItemPicker script

    public void Update()
    {
        hungerSlider.value = hunger;

        if (Input.GetMouseButtonDown(0)) // Check for clicks
        {
            CheckClickedItem();
        }
    }

    void CheckClickedItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            if (hit. collider.TryGetComponent<Item>(out var item))
            {
                if (item.isEdible)
                {
                    hunger = Mathf.Clamp(hunger + hungerIncrease, 0, hunger);
                }
                else
                {
                    hunger = Mathf.Clamp(hunger - hungerDecrease, 0, hunger);
                }

                Destroy(hit.collider.gameObject);
                CheckForEdibleItems();
            }
        }
    }

    void CheckForEdibleItems()
    {
        Item[] remainingItems = FindObjectsOfType<Item>();
        foreach (Item item in remainingItems)
        {
            if (item.isEdible) return;
        }

        itemPicker.DisplayItems(); // Generate new items if no edible ones remain
    }
}
