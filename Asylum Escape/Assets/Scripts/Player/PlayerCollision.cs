using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    // Start is called before the first frame update

    public GameManager gameManager;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            Debug.Log("Trigger");
            gameObject.GetComponent<PlayerMovement>().enabled = false;

            foreach (GameObject chunk in GameObject.FindGameObjectsWithTag("Chunk")) {
                chunk.GetComponent<ChunkMovement>().enabled = false;
            }

            gameManager.GameOver();
        } else if (other.gameObject.tag == "Pill") {
            Destroy(other.gameObject);
            gameManager.AddSanity();
        }
    }
}
