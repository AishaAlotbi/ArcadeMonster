using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public int score = 0;
    public float timer = 60f;
    public int strikes = 0;
    public int maxStrikes = 3;
    public int missedItems = 0;
    public int maxMissedItems = 5;

    void Update()
    {
        // Timer Countdown
        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timer);

        if (timer <= 0 || strikes >= maxStrikes || missedItems >= maxMissedItems)
        {
            GameOver();
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void AddTime(float seconds)
    {
        timer += seconds;
    }

    public void RestoreStrike()
    {
        strikes = Mathf.Max(0, strikes - 1);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Handle game over logic
    }
}
