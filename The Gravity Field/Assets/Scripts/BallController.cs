﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    // Update is called once per frame
    private Rigidbody rb;
    
    public Vector3 movement;
    public int jumpSpeed = 250;
    public int moveSpeed = 2;

    void Start() {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate () {
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(movement * 2.0f);
        
	}
    public void resetMove() {
        movement.x = 0.0f;
        movement.y = 0.0f;
        movement.z = 0.0f;
    }
    public void moveLeft() {
        movement.x = (-1) * moveSpeed;
    }

    public void moveRight() {
        movement.x = moveSpeed;
    }

    public void jump() {
        rb.AddForce(Vector3.up * jumpSpeed);
    }
}
