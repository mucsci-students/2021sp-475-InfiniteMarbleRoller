using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 10);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Destroyer" ) {
            Destroy(this.gameObject);
        }
    }
}
