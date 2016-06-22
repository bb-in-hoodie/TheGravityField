using UnityEngine;
using System.Collections;
using System;

public class AccelObjectManager : MonoBehaviour, AccelInteractive {
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnAccelActive()
    {
        rb.useGravity = true;
    }
}
