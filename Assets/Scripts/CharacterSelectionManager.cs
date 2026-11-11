
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelectionManager : MonoBehaviour
{
    public TMP_Text selectedCharacterText;
    public GameObject startGameButton;

    private int selectedCharacter = 0;
    private bool characterChosen = false;

    void Start()
    {
        selectedCharacterText.gameObject.SetActive(false);
        startGameButton.SetActive(false);
    }

    public void SelectCharacter(int characterNumber)
    {
        selectedCharacter = characterNumber;
        characterChosen = true;

        selectedCharacterText.text =
            "Selected: Character " + (characterNumber + 1);

        selectedCharacterText.gameObject.SetActive(true);
        startGameButton.SetActive(true);

        Debug.Log("Selected Character: " + characterNumber);
    }

    public void StartGame()
    {
        if (!characterChosen) return;

        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        PlayerPrefs.Save();

        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
}
