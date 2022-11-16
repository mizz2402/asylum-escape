using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerPosition;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            playerPosition.x -= 1;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            playerPosition.x += 1;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (playerPosition.x < transform.position.x)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        else if (playerPosition.x > transform.position.x)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.position = playerPosition;
    }
}
