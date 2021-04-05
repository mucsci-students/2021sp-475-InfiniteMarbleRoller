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
    public GameObject Camera;
    private bool showing = true;
    private int rotationSpeed = - 350;

    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_GainHeart;
    [SerializeField] private AudioClip m_Hit;

    void Start() {
        rb = GetComponent<Rigidbody>();
        GameManager = GameManagerObj.GetComponent<GameManager>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
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
            rotationSpeed *= -1;
        }
    }
    
    void FixedUpdate() {
        rb.AddForce(new Vector3(0, moveSpeed, 0));
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Block")
        {

            if (!safe)
            {
                Destroy(collider.gameObject);
                safe = true;
                GameManager.deductHealth();
                m_AudioSource.clip = m_Hit;
                m_AudioSource.Play();
            }
        }
        else if (collider.gameObject.tag == "Heart")
        {
            GameManager.addHealth();
            Destroy(collider.gameObject);
            m_AudioSource.clip = m_GainHeart;
            m_AudioSource.Play();
        }
        else if (collider.gameObject.tag == "Flip")
        {
            Camera.GetComponent<CameraFlipper>().flipTheCamera();
            Destroy(collider.gameObject);
            safeTime = 2.5f;
            safe = true;
        }
    }
}
