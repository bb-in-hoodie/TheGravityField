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
		
		// move left or right
		if (moveHorizontal < 0) 
			Move(-1);
		else if (moveHorizontal > 0)		
			Move(1);
		
        // jump when you press space bar button
        if (Input.GetButton("Jump")) 
     		Jump();
	}

	void Move(int direction)
	{	
		Vector3 movement = new Vector3 (direction, 0.0f, 0.0f);
		rb.AddForce (movement * speed);
	}

	void Jump()
	{
		rb.AddForce(Vector3.up * jumpSpeed);
	}
		
}
