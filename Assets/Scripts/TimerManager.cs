using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startingTime = 60f;
    public TMP_Text timerText;

    [Header("Player")]
    public PlayerDeath playerDeath;

    private float timeRemaining;
    private bool timerRunning = true;

    void Start()
    {
        timeRemaining = startingTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            UpdateTimerDisplay();

            timerRunning = false;

            Debug.Log("Time ran out! Player died!");

            if (playerDeath != null)
            {
                playerDeath.Die();
            }

            return;
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);

        timerText.text = "Time: " + seconds;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
