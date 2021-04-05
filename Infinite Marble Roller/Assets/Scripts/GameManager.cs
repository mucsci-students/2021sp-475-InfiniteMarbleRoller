using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    //public variables
    public float updateTime = 2.5f;
    public GameObject[] prefabArr;
    public GameObject[] healthPrefabArr;
    public GameObject[] coinPrefabArr;
    public GamePauseScreen gamePauseScreen;
    public GameOverScreen gameOverScreen;
    public GameObject PauseObject;
    public GameObject OverObject;
    public HealthBar HealthBar;
    public Camera Main;
    public Camera PauseCam;
    public Camera OverCam;
    public GameObject scoreBoard;
    public static List<float> highScores = new List<float>(new float[] {0, 0, 0, 0, 0});


    //private variables
    private float remainingTime;
    private string previousPrefab;
    private int health = 3;
    private const float speedUpTimeRate = 0.01f;
    private const float speedUpUpdateTime = 0.005f;
    private float timeScale;
    private bool isDead;
    private int healthTime = 10;
    private int coinTime = 8;
    private Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
      Main.enabled = true;
      PauseCam.enabled = false;
      OverCam.enabled = false;
      Time.timeScale = 1;
      timeScale = 1;
      remainingTime = updateTime;
      GameObject chosenPrefab = prefabArr[Random.Range(0, prefabArr.Length)];
      Instantiate(chosenPrefab, new Vector3(25, 0, 0), Quaternion.identity);
      previousPrefab = chosenPrefab.name.Substring(chosenPrefab.name.Length - 2);
      if(previousPrefab.Contains("e")) {
        previousPrefab = chosenPrefab.name.Substring(chosenPrefab.name.Length - 1);
      }
      gamePauseScreen = PauseObject.GetComponent<GamePauseScreen>();
      gameOverScreen = OverObject.GetComponent<GameOverScreen>();
      scoreScript = scoreBoard.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
      remainingTime -= Time.deltaTime;
      if (remainingTime <= 0.0f) {
        timerEnded();
        updateTime += speedUpUpdateTime;
        timeScale += speedUpTimeRate;

        remainingTime = updateTime;
        Time.timeScale = timeScale;
      }

      if(Input.GetKey("escape") && gameOverScreen.activeInfo == false) 
      {   
        gamePauseScreen.Setup();
      }

      if(isDead && gamePauseScreen.activeInfo == false)
      {
        gameOverScreen.Setup();
      }

    }

    private void timerEnded() {
      if (healthTime == 0) {
        GameObject chosenPrefab = healthPrefabArr[Random.Range(0, healthPrefabArr.Length)];
        createPrefab(chosenPrefab);
        healthTime = 10;
      } else if (coinTime == 0) {
        GameObject chosenPrefab = coinPrefabArr[Random.Range(0, coinPrefabArr.Length)];
        createPrefab(chosenPrefab);
        coinTime = 8;
      } else {
        GameObject chosenPrefab = prefabArr[Random.Range(0, prefabArr.Length)];
        createPrefab(chosenPrefab);
      }
    }

    private void createPrefab (GameObject chosenPrefab)
    {
      var result = chosenPrefab.name.Substring(chosenPrefab.name.Length - 2);

      if(result.Contains("e")) {
        result = chosenPrefab.name.Substring(chosenPrefab.name.Length - 1);
      }
      if (result == previousPrefab) {
        timerEnded();
      } else {
        Instantiate(chosenPrefab, new Vector3(25, 0, 0), Quaternion.identity);
        previousPrefab = result;
        --healthTime;
        --coinTime;
      }
    }

    public void deductHealth()
    {
        if (health > 0)
            health -= 1;
        HealthBar.SetHealth(health);
        if (health == 0)
        {
          isDead = true;
          for (int x = 5; x > 0; --x) {
              if(scoreScript.curScore > highScores[x-1]) {
                  highScores.RemoveAt(0);
                  highScores.Insert(x-1, scoreScript.curScore);        
                  break;
              }
          }
        }
    }

    public bool checkStatus()
    {
      return isDead;
    }

    public void addHealth()
    {
        if (health < 3)
            health += 1;
        HealthBar.SetHealth(health);
    }

    public float getTimeScale()
    {
      return timeScale;
    }
}
