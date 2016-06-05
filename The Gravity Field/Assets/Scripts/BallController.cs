using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    int jumpSpeed = 350;
    int moveSpeed = 4;
    bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * 2.0f);
    }

    public void ResetMove()
    {
        movement.x = 0.0f;
        movement.y = 0.0f;
    }
    public void MoveLeft() { movement.x = (-1) * moveSpeed; }
    public void MoveRight() { movement.x = moveSpeed; }

    public void jump()
    {
        // Jumping is only available when the ball is on the ground
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpSpeed);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        // If the ball hits the ground, let 'isJumping' be false
        if (isJumping && c.gameObject.tag == "MAP")
            isJumping = false;
    }
}
