using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    public TMP_Text levelText;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.StartsWith("Level"))
        {
            levelText.text = sceneName.Replace("Level", "Level ");
        }
        else
        {
            levelText.text = sceneName;
        }
    }
}
