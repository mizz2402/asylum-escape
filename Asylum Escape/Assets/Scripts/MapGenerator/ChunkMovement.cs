using UnityEngine;

public class ChunkMovement : MonoBehaviour {
    public float speed = 15f;
    private float destroyOffset;
    private Vector3 direction = Vector3.forward;
    // Start is called before the first frame update
    void Start() {
        destroyOffset = GetComponent<Collider>().bounds.size.z * -1;
        if (transform.rotation.Equals(Quaternion.identity)) {
            direction = Vector3.back;
        }
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.z < destroyOffset)
            Destroy(gameObject);
    }
}
