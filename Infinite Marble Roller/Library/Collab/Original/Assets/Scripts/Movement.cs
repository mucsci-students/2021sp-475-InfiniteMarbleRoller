using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    Vector2 movement;
    private Rigidbody rb;
    private float safeTime = 5.0f;
    private float flashTime = 0.22f;
    private bool safe = false;
    public GameObject GameManagerObj;
    private GameManager GameManager;
    private bool showing = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
        GameManager = GameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (safe) {
            safeTime -= Time.deltaTime;
            flashTime -= Time.deltaTime;
            if (flashTime <= 0) {
                if(showing) {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                    showing = false;
                    flashTime = 0.22f;
                } else {
                    this.GetComponent<SpriteRenderer>().enabled = true;
                    flashTime = 0.22f;
                    showing = true;
                }
            }
            if(safeTime <= 0) {
                safeTime = 5.0f;
                this.GetComponent<SpriteRenderer>().enabled = true;
                showing = true;
                safe = false;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed *= -1;
        }
    }
    
    void FixedUpdate() {
        rb.AddForce(new Vector3(0, moveSpeed, 0));
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Block") {
            if(!safe) {
                Destroy(collider.gameObject);
                safe = true;
                Debug.Log("Lose a Life");
                GameManager.deductHealth();
            }
        } else if (collider.gameObject.tag == "Heart") {
            Debug.Log("Gain a Life!");
            GameManager.addHealth();
            Destroy(collider.gameObject);
        }
    }
}
