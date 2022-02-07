using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip menuMusic;


    void Start()
    {
        PlaySound(menuMusic);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Pacman");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
