using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public TMP_Text levelCompleteText;

    public TimerManager timerManager;

    private bool levelFinished = false;

    void Start()
    {
        levelCompleteText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelFinished) return;

        if (collision.CompareTag("Player"))
        {
            levelFinished = true;

            if (timerManager != null)
            {
                timerManager.StopTimer();
            }

            // Show the completion message
            levelCompleteText.gameObject.SetActive(true);

            // Stop the player
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
                playerRb.simulated = false;
            }

            // Disable player movement
            PlayerMovement movement =
                collision.GetComponent<PlayerMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }

            Debug.Log("Level Complete!");
        }
    }
}