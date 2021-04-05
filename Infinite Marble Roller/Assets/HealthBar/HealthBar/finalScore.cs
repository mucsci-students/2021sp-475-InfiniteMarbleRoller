using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Final Score:  " + PlayerPrefs.GetInt("PlayerScore").ToString() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
