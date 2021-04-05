using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public float curScore;
    public Text  scoretext;

    void Start()
    {
        curScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        curScore += Time.deltaTime;
        scoretext.text = curScore.ToString("F1");
    }
    
}
