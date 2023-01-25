using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour {
    public GameObject[] mapChunkPrefabs;
    public int minChunksCount = 6;
    private int chunksCount = 0;
    private Vector3 instantiatePosition = new Vector3(0f, 0f, 22f);
    private GameObject lastSpawnedObject;
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
    }

    private GameObject GetRandomMapChunk() {
        int rndIndex = Random.Range(0, mapChunkPrefabs.Length);
        return mapChunkPrefabs[rndIndex];
    }

    private Quaternion GetRandomQuaternion() {
        float rndIndex = Random.Range(0f, 1f);
        if (rndIndex < 0.5f)
            return Quaternion.Euler(0f, 180f, 0f);
        return Quaternion.identity;
    }
}
