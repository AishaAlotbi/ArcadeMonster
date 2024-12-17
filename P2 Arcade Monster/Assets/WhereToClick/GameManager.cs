using UnityEngine;
using UnityEngine.UI; 

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
        timer = 60f; // Initial time 
        missedItems = 0;

       
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
            // Handle game over 
            GameOver();
        }
        UpdateUI(); // Update UI 
    }

    // Restore a strike (for red tomatoes)
    public void RestoreStrike()
    {
        strikes++;
        if (strikes > 3) strikes = 3; // Ensure max strikes doesn't exceeeeed 3
        UpdateUI(); // Update UI after strike change
    }

    //  time 
    public void AddTime(float seconds)
    {
        timer += seconds;
        UpdateUI(); // Update UI
    }

    void UpdateUI()
    {
        //  UI text 
        scoreText.text = "Score: " + score.ToString();
        strikesText.text = "Strikes: " + strikes.ToString();
        
    }

    void Update()
    {
        // Update timer 
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //  gmae over 
            GameOver();
        }

        // UpdateUI 
        UpdateUI();
    }

    // Game Over Logic
    void GameOver()
    {
        // when strikes hit 0 or timer reaches 0
        Debug.Log("Game Over!");
        
    }
}
