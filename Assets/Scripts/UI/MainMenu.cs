using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject grandPrixMenu;
    [SerializeField] private GameObject timeTrialMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject exitMenu;
    public AudioSource sfxSource;
    public List<AudioClip> AudioClips;

    public void openGrandPrixMenu()
    {
        sfxSource.clip = AudioClips[1];
        sfxSource.Play();
    }

    public void hoverOverButton()
    {
        sfxSource.clip = AudioClips[0];
        sfxSource.Play();
    }
}
