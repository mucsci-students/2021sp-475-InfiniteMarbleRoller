using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public GameObject nightBackground;

    public const float updateTime = 20.0f;
    private float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
      remainingTime = updateTime;
      Instantiate(nightBackground, new Vector3(0, 0, 0), Quaternion.identity);
      Instantiate(nightBackground, new Vector3(31, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      remainingTime -= Time.deltaTime;
      if (remainingTime <= 0.0f) {
        timerEnded();
        remainingTime = updateTime;
      }
    }

    private void timerEnded() {
      Instantiate(nightBackground, new Vector3(31, 0, 0), Quaternion.identity);
      nightBackground.transform.Translate(Vector3.left * Time.deltaTime);
    }

}
