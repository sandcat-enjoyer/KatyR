using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstMenu;
    [SerializeField] private GameObject grandPrixMenu;
    [SerializeField] private GameObject courseSelectMenu;
    [SerializeField] private GameObject timeTrialMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject exitMenu;
    public AudioSource sfxSource;
    public List<AudioClip> AudioClips;
    [SerializeField] private List<GameObject> characters;
    private int selectedCharacterIndex = -1;

    public void openGrandPrixMenu()
    {
        sfxSource.clip = AudioClips[1];
        sfxSource.Play();
        firstMenu.SetActive(false);
        grandPrixMenu.SetActive(true);
    }

    public void hoverOverButton()
    {
        sfxSource.clip = AudioClips[0];
        sfxSource.Play();
    }
    
    // Call this method when a character is selected (e.g., from a button click)
    public void SelectCharacter(int characterIndex)
    {
        hoverOverButton();
        if (selectedCharacterIndex == characterIndex)
            return; // Avoid re-selecting the same character

        // Disable the previously displayed character (if any)
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characters.Count)
            characters[selectedCharacterIndex].SetActive(false);

        // Enable and set the new character 3D model
        if (characterIndex >= 0 && characterIndex < characters.Count)
            characters[characterIndex].SetActive(true);

        // Set the character's name in the Text component
        //characterNameText.text = "Selected: " + characterName;

        selectedCharacterIndex = characterIndex;
    }

    public void ClickOnCharacter(int characterIndex)
    {
        sfxSource.clip = AudioClips[1];
        sfxSource.Play();
        courseSelectMenu.SetActive(true);
        grandPrixMenu.SetActive(false);
        //additional code needed for bringing over the right character into the race track but that's for later
        //this is just to get the basics down already
    }
}
