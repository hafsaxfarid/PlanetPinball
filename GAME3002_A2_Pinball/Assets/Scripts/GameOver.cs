using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private bool isGameOver = false;

    [SerializeField]
    private GameObject gameUI;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private BallControl ball;

    private void Update()
    {
        if(ball.m_lives == 0)
        {
            GameOverState();
        }
    }

    public void GameOverState()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        Debug.Log("GAME OVER");
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
