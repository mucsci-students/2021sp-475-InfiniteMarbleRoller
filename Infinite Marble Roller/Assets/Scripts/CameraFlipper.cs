using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlipper : MonoBehaviour
{
    public Animator anim;
    public bool flippedState;
    // Start is called before the first frame update
    void Start()
    {
        flippedState = false;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void flipTheCamera()
    {
        if (flippedState)
        {
            anim.Play("FlipCameraBack");
            flippedState = false;
        }
        else
        {
            anim.Play("FlipCamera");
            flippedState = true;
        }
    }
}
