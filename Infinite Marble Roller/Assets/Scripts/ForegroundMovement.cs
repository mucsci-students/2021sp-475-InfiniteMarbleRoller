using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundMovement : MonoBehaviour
{
    public GameObject foreground;

    public const float updateTime = 3.0f;
    private float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = updateTime;
        Instantiate(foreground, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(foreground, new Vector3(31, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0.0f)
        {
            timerEnded();
            remainingTime = updateTime;
        }
    }

    private void timerEnded()
    {
        Instantiate(foreground, new Vector3(31, 0, 0), Quaternion.identity);
        foreground.transform.Translate(Vector3.left * Time.deltaTime * 10);
    }

}