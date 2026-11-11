using UnityEngine;

public class CharacterAppearance : MonoBehaviour
{
    public Sprite[] characters;

    void Start()
    {
        int selectedCharacter =
            PlayerPrefs.GetInt("SelectedCharacter", 0);

        SpriteRenderer spriteRenderer =
            GetComponent<SpriteRenderer>();

        if (spriteRenderer != null &&
            selectedCharacter >= 0 &&
            selectedCharacter < characters.Length)
        {
            spriteRenderer.sprite = characters[selectedCharacter];
        }
        else
        {
            Debug.LogError("Character sprite or selection is missing!");
        }
    }
}
