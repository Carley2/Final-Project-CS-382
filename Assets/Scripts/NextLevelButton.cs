using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;

        int nextLevel =
            SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            Debug.Log("Congratulations! You completed the game!");
        }
    }
}
