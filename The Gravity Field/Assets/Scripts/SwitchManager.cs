using UnityEngine;
using System.Collections;

public class SwitchManager : MonoBehaviour {

	// Use this for initialization
    GeneratorManager gen;

    // Use this for initialization
    void Start()
    {
        gen = GameObject.Find("Generator").GetComponent<GeneratorManager>();
    }
	
	void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint cp in col.contacts)
        {
            if (cp.otherCollider.tag == "BALL" || cp.otherCollider.tag == "FALLING" || cp.otherCollider.tag == "OBSTACLE" )
                gen.shouldStop = false;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "BALL" || col.collider.tag == "FALLING" || col.collider.tag == "OBSTACLE")
            gen.shouldStop = true;
    }


    void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "BALL")
    		gen.shouldStop = false;
    }

    void OnTriggerExit(Collider other)
    {
    	if(other.tag == "BALL")
    		gen.shouldStop = true;
    }
}
