using UnityEngine;
using System.Collections;

public class BreachableFloorManager : MonoBehaviour {
    public float velThres = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "BALL" || col.tag == "FALLING")
            print(col.GetComponent<Rigidbody>().velocity);

        if( (col.tag == "BALL" || col.tag == "FALLING" ) && col.GetComponent<Rigidbody>().velocity.y < -velThres)
        {
            Destroy(transform.FindChild("Prop").gameObject);
            foreach (BFManager bfm in transform.GetComponentsInChildren<BFManager>())
            {
                if (bfm.gameObject.name == "BF")
                    bfm.SendMessage("DestroyBF");
            }
        }
    }    
}
