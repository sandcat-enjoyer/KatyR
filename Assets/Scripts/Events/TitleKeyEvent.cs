using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleKeyEvent : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private float clipDuration;

    private void Start()
    {
        clipDuration = _audioSource.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _audioSource.Play();
            Invoke(nameof(ChangeScene), clipDuration);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
