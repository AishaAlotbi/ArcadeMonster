using UnityEngine;

public class SceneEditor : MonoBehaviour
{
    public Sprite[] backgrounds; // Backgrounds to swap through
    public SpriteRenderer backgroundRenderer;
    public GameObject[] sceneObjects; // Objects to change sprites on
    public Sprite[] newSprites; // Sprites to use after changes
    private float timer;

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 20f && timer < 40f)
        {
            ChangeScene(0); // First change
        }
        else if (timer >= 40f && timer < 60f)
        {
            ChangeScene(1); // Second change
        }
        else if (timer >= 60f)
        {
            ChangeScene(2); // Third change
        }
    }

    void ChangeScene(int index)
    {
        if (index < backgrounds.Length)
        {
            backgroundRenderer.sprite = backgrounds[index];

            for (int i = 0; i < sceneObjects.Length && i < newSprites.Length; i++)
            {
                sceneObjects[i].GetComponent<SpriteRenderer>().sprite = newSprites[i];
            }
        }
    }
}
