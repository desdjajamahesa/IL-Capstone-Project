using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManagerSM audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerSM>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioManager.PlaySFX(audioManager.startGameBtn);
    }

    public void Select()
    {
        audioManager.PlaySFX(audioManager.selectBtn);
    }

    public void Back()
    {
        audioManager.PlaySFX(audioManager.backBtn);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}