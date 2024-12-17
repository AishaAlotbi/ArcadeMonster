using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;  
public class GameOver : MonoBehaviour
{
    public Button restartButton;  //  Restart button
    public Button exitButton;     //  Exit button
    public AudioSource gameOverAudio;  //  game over sound

    void Start()
    {
        // Play game over audio 
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }

        // Add listeners 
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);  // Restart button action
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);  // Exit button action
        }
    }

    // Restart the game 
    void RestartGame()
    {
        SceneManager.LoadScene("MainScene");  // MAAiN Scene
    }

    // Exit 
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  
#else
        Application.Quit();  // For build use
#endif
    }
}
