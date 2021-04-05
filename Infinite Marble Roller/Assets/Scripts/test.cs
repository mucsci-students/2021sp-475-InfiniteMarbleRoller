using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Destroyer" ) {
            Destroy(this.gameObject);
        }
    }

}
