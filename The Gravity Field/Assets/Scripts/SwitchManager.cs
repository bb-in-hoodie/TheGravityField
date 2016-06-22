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
