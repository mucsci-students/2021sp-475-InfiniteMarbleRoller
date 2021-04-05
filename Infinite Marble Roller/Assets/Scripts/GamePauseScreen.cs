using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseScreen : MonoBehaviour
{
    public bool activeInfo = false;
    public GameObject Manager;
    public Camera Main;
    public Camera OtherCam;

    private float timeScale;

    public void Setup()
    {
        Main.enabled = false;
        OtherCam.enabled = true;
        timeScale = Manager.GetComponent<GameManager>().getTimeScale();
        activeInfo = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Main.enabled = true;
        OtherCam.enabled = false;
        activeInfo = false;
        gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }
}
