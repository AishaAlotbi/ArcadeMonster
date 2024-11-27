using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GunScript gun;
    public int gameOverScore = 250;
    public string nextSceneName;

    public void Update()
    {
        if (gun.GetScore() >= gameOverScore)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        Debug.Log("Game Over! Loading next scene...");
        SceneManager.LoadScene(nextSceneName);
    }
}
