using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;  
public class GameOver : MonoBehaviour
{
    public Button restartButton;  // Reference to the Restart button
    public Button exitButton;     // Reference to the Exit button
    public AudioSource gameOverAudio;  // Reference to the audio source for game over sound

    void Start()
    {
        // Play game over audio on scene load
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }

        // Add listeners to buttons to handle click events
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);  // Restart button action
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);  // Exit button action
        }
    }

    // Restart the game (reload the main scene)
    void RestartGame()
    {
        SceneManager.LoadScene("MainScene");  // Make sure the scene name is "Main" or as per your setup
    }

    // Exit the application
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // For editor use
#else
        Application.Quit();  // For build use
#endif
    }
}
