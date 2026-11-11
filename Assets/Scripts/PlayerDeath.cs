using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip deathSound;
    private bool isDead = false;

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        Debug.Log("Player died!");

        // Play the death sound
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(
                deathSound,
                transform.position,
                1f
            );
        }

        // Display the Game Over screen
        if (GameOverManager.Instance != null)
        {
            GameOverManager.Instance.ShowGameOver();
        }

        Destroy(gameObject);
    }
}
