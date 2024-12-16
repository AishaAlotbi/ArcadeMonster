using UnityEngine;
using UnityEngine.UI; // For regular Unity UI
// using TMPro; // Uncomment this line if you're using TextMeshPro instead of regular UI Text

public class GameManager : MonoBehaviour
{
    public int score;
    public int strikes;
    public float timer;
    public int missedItems;

    // UI Elements
    public Text scoreText;      
    public Text strikesText;  
    public Text timerText;      
   
    void Start()
    {
        score = 0;
        strikes = 3; // Start with 3 strikes
        timer = 60f; // Initial time (can change as needed)
        missedItems = 0;

        // Initial UI Update
        UpdateUI();
    }

    // Update the score
    public void UpdateScore()
    {
        score++;
        UpdateUI(); // Update UI after score change
    }

    // Add a strike
    public void AddStrike()
    {
        strikes--;
        if (strikes <= 0)
        {
            // Handle game over logic if strikes are 0
            GameOver();
        }
        UpdateUI(); // Update UI after strike change
    }

    // Restore a strike (for red tomatoes)
    public void RestoreStrike()
    {
        strikes++;
        if (strikes > 3) strikes = 3; // Ensure max strikes doesn't exceed 3
        UpdateUI(); // Update UI after strike change
    }

    //  time 
    public void AddTime(float seconds)
    {
        timer += seconds;
        UpdateUI(); // Update UI after time change
    }

    void UpdateUI()
    {
        //  UI text 
        scoreText.text = "Score: " + score.ToString();
        strikesText.text = "Strikes: " + strikes.ToString();
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString() + "s"; // Ceil the timer to show whole seconds
    }

    void Update()
    {
        // Update timer logic here if necessary (for countdown, etc.)
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //  gmae over 
            GameOver();
        }

        // UpdateUI every frame to make sure the UI stays up-to-date
        UpdateUI();
    }

    // Game Over Logic
    void GameOver()
    {
        // Game Over when strikes hit 0 or timer reaches 0
        Debug.Log("Game Over!");
        // Implement any additional game over logic here (like stopping spawning, showing a Game Over screen, etc.)
    }
}
