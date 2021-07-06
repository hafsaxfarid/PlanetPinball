using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool isPaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Game Paused...");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Resuming Game!");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Loading Main Menu...");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit...");
    }
}
