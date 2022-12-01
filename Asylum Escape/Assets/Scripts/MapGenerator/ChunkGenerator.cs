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
        lastSpawnedObject = Instantiate(GetRandomMapChunk(), instantiatePosition, Quaternion.identity);
        chunksCount++;
    }

    private void FixedUpdate() {
        if (chunksCount < minChunksCount || lastSpawnedObject.transform.position.z < instantiatePosition.z - length) {
            instantiatePosition = lastSpawnedObject.transform.position;
            length = lastSpawnedObject.GetComponent<Collider>().bounds.size.z;
            instantiatePosition.z += length;
            lastSpawnedObject = Instantiate(GetRandomMapChunk(), instantiatePosition, Quaternion.identity);
            chunksCount++;
        }
    }

    private GameObject GetRandomMapChunk() {
        int rndIndex = Random.Range(0, mapChunkPrefabs.Length - 1);
        return mapChunkPrefabs[rndIndex];
    }
}
