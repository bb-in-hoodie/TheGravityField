using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public BallController other;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * speed);
    }

    void OnCollisionEnter (Collision col)
    {
        
        if(col.gameObject.tag == "MAP")
        {
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "BALL")
        {
            col.gameObject.GetComponent<BallController>().Dead();
        }
    }
}