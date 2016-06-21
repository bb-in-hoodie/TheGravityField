using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

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
    }
}