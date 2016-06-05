using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    // Update is called once per frame
    private Rigidbody rb;
    bool isJumping = false;
    int jumpSpeed = 350;
    int moveSpeed = 4;
    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * 2.0f);
    }

    public void resetMove()
    {
        movement.x = 0.0f;
        movement.y = 0.0f;
    }
    public void moveLeft()
    {
        movement.x = (-1) * moveSpeed;
    }

    public void moveRight()
    {
        movement.x = moveSpeed;
    }

    public void jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpSpeed);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (isJumping && c.gameObject.tag == "MAP")
            isJumping = false;
    }
}
