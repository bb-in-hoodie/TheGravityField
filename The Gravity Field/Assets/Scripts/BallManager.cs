using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {
	
	public float speed;
	public float jumpSpeed;
    private Rigidbody rb;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

        // move left or right
        rb.AddForce (movement * speed);

        // jump when you press space bar button
        if (Input.GetButton("Jump")) 
     		rb.AddForce(Vector3.up * jumpSpeed);
	}
	

	

}
