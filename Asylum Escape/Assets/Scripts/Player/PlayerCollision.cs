using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
