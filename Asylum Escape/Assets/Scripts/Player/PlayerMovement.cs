using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10f;
    public float step = 1f;

    private Vector3 targetPosition;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start() {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /**
     * First check is key is pressed (moveLeft key or moveRight key) - if so change target position.
     * Then call MovePlayer() method.
     */
    void Update() {
        if (Input.GetKeyDown(moveLeft) && !(targetPosition.x - step < -step)) {
            targetPosition.x -= step;
            animator.SetBool("Left", true);
        } else if (Input.GetKeyDown(moveRight) && !(targetPosition.x + step > step)) {
            targetPosition.x += step;
            animator.SetBool("Right", true);
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Jump");
        }
        MovePlayer();
    }

    /**
     * If distance between player and target position is less than 0.01 then make them equal
     * (to fix method Vector3.Lerp() not moving object to exact desired position).
     * 
     * If distance is bigger than player is moved lineraly from it's current position to target position.
     * 
     * Method results in moving player object left or right.
     */
    void MovePlayer() {
        float diff = Mathf.Abs(targetPosition.x - transform.position.x);
        if (targetPosition.x != transform.position.x && diff < 0.15f)
            transform.position = new Vector3(targetPosition.x, transform.position.y, 0f);
        else {
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, transform.position.y, 0f), speed * Time.deltaTime);
            if (diff < 0.5f) {
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
            }
        }
    }
}
