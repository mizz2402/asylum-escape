using UnityEngine;

public class ChunkGenerator : MonoBehaviour {
    public float gameSpeed = 1f;
    public AudioSource music;
    public GameObject[] mapChunkPrefabs;
    public int minChunksCount = 6;
    private int chunksCount = 0;
    private Vector3 instantiatePosition = new Vector3(0f, 0f, 22f);
    private GameObject lastSpawnedObject;
    private int lastSpawnedObjectIndex = 0;
    private float length;

    void Awake() {
        lastSpawnedObject = Instantiate(mapChunkPrefabs[0], instantiatePosition, Quaternion.identity);
        chunksCount++;
    }

    private void FixedUpdate() {
        if (chunksCount < minChunksCount || lastSpawnedObject.transform.position.z < instantiatePosition.z - length) {
            instantiatePosition = lastSpawnedObject.transform.position;
            length = lastSpawnedObject.GetComponent<Collider>().bounds.size.z;
            instantiatePosition.z += length;
            lastSpawnedObject = Instantiate(GetRandomMapChunk(), instantiatePosition, GetRandomQuaternion());
            chunksCount++;
        }
        Time.timeScale = gameSpeed;
        music.pitch = gameSpeed;
    }

    private GameObject GetRandomMapChunk() {
        if (mapChunkPrefabs.Length <= 2)
            return mapChunkPrefabs[mapChunkPrefabs.Length - 1];

        int rndIndex;
        do
            rndIndex = Random.Range(1, mapChunkPrefabs.Length);
        while (rndIndex == lastSpawnedObjectIndex);
        lastSpawnedObjectIndex = rndIndex;

        return mapChunkPrefabs[rndIndex];
    }

    private Quaternion GetRandomQuaternion() {
        float rndIndex = Random.Range(0f, 1f);
        if (rndIndex < 0.5f)
            return Quaternion.Euler(0f, 180f, 0f);
        return Quaternion.identity;
    }
}
