using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public GameObject[] allItems; // Array of all possible items
    public Transform[] spawnPoints; // Points where items will be displayed
    private GameObject[] currentItems; // Track displayed items

    void Start()
    {
        DisplayItems();
    }

    public void DisplayItems()
    {
        ClearItems();

        currentItems = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, allItems.Length);
            GameObject item = Instantiate(allItems[randomIndex], spawnPoints[i].position, Quaternion.identity);
            currentItems[i] = item;
        }
    }

    private void ClearItems()
    {
        if (currentItems != null)
        {
            foreach (GameObject item in currentItems)
            {
                if (item != null) Destroy(item);
            }
        }
    }
}
