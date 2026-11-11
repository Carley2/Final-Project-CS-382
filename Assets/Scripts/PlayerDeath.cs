using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip deathSound;
    public BackgroundMusicManager backgroundMusic;

    public float deathSoundVolume = 20f;

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
                deathSoundVolume
            );
        }

        // Lower the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.LowerMusicVolume();
        }

        // Display the Game Over screen
        if (GameOverManager.Instance != null)
        {
            GameOverManager.Instance.ShowGameOver();
        }

        Destroy(gameObject);
    }
}
