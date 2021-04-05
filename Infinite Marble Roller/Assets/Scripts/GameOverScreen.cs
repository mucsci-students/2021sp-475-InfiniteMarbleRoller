using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public bool activeInfo = false;
    public Camera Main;
    public Camera OverCam;
    public Text highScoreText;

    public void Setup()
    {
        Main.enabled = false;
        OverCam.enabled = true;
        activeInfo = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
        highScoreText.text = 
            "1st:  " + GameManager.highScores[4].ToString() + "\n"
            + "2nd: " + GameManager.highScores[3].ToString() + "\n"
            + "3rd:  " + GameManager.highScores[2].ToString() + "\n"
            + "4th:  " + GameManager.highScores[1].ToString() + "\n"
            + "5th:  " + GameManager.highScores[0].ToString();
    }
}
