using UnityEngine;

public class PillSpawner : MonoBehaviour
{
    public GameObject pillPrefab;
    public float spawnRate = 0.25f;
    public float rotationSpeed = 150f;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) <= spawnRate)
            Instantiate(pillPrefab, gameObject.transform);
    }

    void Update() {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
