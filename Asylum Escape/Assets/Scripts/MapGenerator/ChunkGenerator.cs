using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour {
    public GameObject mapChunkPrefab;
    public Vector3 instantiateStartPosition = new Vector3(0f, 0f, 22f);
    private Vector3 nextInstantiatePosition;
    private float instantiateOffset = 5f;
    private GameObject lastSpawnedObject;

    // Start is called before the first frame update
    void Start() {
        nextInstantiatePosition = instantiateStartPosition;
        //nextInstantiatePosition.z += instantiateOffset;
        lastSpawnedObject = GameObject.Instantiate(mapChunkPrefab, instantiateStartPosition, Quaternion.identity);
        Vector3 size = lastSpawnedObject.GetComponent<Collider>().bounds.size;
        nextInstantiatePosition.z += size.z;
        Debug.Log(size);
        Debug.Log(nextInstantiatePosition);
        //lastSpawnedObject = GameObject.Instantiate(mapChunkPrefab, nextInstantiatePosition, Quaternion.identity);
    }

    private void FixedUpdate() {
        if (lastSpawnedObject.transform.position.z < instantiateStartPosition.z - instantiateOffset) {
            Vector3 spawnPosition = nextInstantiatePosition;
            spawnPosition.z -= instantiateStartPosition.z - lastSpawnedObject.transform.position.z;
            lastSpawnedObject = GameObject.Instantiate(mapChunkPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
