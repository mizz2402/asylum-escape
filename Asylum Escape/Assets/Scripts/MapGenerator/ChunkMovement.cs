using UnityEngine;

public class ChunkMovement : MonoBehaviour {
    public float speed = 15f;
    private float destroyOffset;
    // Start is called before the first frame update
    void Start() {
        destroyOffset = GetComponent<Collider>().bounds.size.z * -1;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < destroyOffset)
            Destroy(gameObject);
    }
}
