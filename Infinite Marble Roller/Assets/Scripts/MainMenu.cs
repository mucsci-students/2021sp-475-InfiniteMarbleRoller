using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GamePauseScreen gamePauseScreen;
    public GameObject scoreBoardWindow;
    public Text scoreText;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        // SceneManager.LoadScene("Game");
        Debug.Log("exitgame");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        gamePauseScreen.Resume();
    }

    public void options() 
    {
        SceneManager.LoadScene("Options");
    }

    public void doScoreMenu()
    {
        scoreBoardWindow.SetActive(true);
        scoreText.text = 
            "High Scores:\n"
            + "1st:  " + GameManager.highScores[4].ToString() + "\n"
            + "2nd: " + GameManager.highScores[3].ToString() + "\n"
            + "3rd:  " + GameManager.highScores[2].ToString() + "\n"
            + "4th:  " + GameManager.highScores[1].ToString() + "\n"
            + "5th:  " + GameManager.highScores[0].ToString();
    }

    public void closeScoreMenu()
    {
        scoreBoardWindow.SetActive(false);
    }
}