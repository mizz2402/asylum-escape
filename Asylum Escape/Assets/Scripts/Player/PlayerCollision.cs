using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            Debug.Log("Trigger");
            //gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
