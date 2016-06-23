using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    FieldManager fm;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fm = GameObject.Find("Field").GetComponent<FieldManager>();
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * speed);
    }

    void OnCollisionEnter (Collision col)
    {        
        if(col.gameObject.tag == "BALL" && col.gameObject.GetComponent<BallController>().GetIsDead() == false)
            col.gameObject.GetComponent<BallController>().Dead();

        fm.RemoveFromList(gameObject.GetComponent<Collider>());
        Destroy(this.gameObject);
    }
}