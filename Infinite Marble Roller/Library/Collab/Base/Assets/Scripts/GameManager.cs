using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    //public variables
    public const float updateTime = 2.5f;
    public GameObject[] prefabArr;
    public GamePauseScreen gamePauseScreen;
    public GameOverScreen gameOverScreen;
    public GameObject test;

    //private variables
    private float remainingTime;
    private GameObject previousPrefab;

    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      remainingTime = updateTime;
      GameObject chosenPrefab = prefabArr[Random.Range(0, prefabArr.Length)];
      Instantiate(chosenPrefab, new Vector3(25, 0, 0), Quaternion.identity);
      previousPrefab = chosenPrefab;
      gamePauseScreen = test.GetComponent<GamePauseScreen>();
    }

    // Update is called once per frame
    void Update()
    {
      remainingTime -= Time.deltaTime;
      if (remainingTime <= 0.0f) {
        timerEnded();
        remainingTime = updateTime;
      }

      if(Input.GetKey("escape")) 
      {   
          gamePauseScreen.Setup();
      }

    }

    private void timerEnded() {
      GameObject chosenPrefab = prefabArr[Random.Range(0, prefabArr.Length)];
      if (chosenPrefab == previousPrefab) {
        timerEnded();
      } else {
        Instantiate(chosenPrefab, new Vector3(25, 0, 0), Quaternion.identity);
        previousPrefab = chosenPrefab;
      }
    }
}
