using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelManager : MonoBehaviour
{
    public GameObject targetObj;
    float lastZ, curZ, zThres = 0.5f;
    bool isBallInside = false;

	// Use this for initialization
	void Start () {
        lastZ = Input.acceleration.z;
        curZ = Input.acceleration.z;
        StartCoroutine("UpdateZ");
    }
	
	// Update is called once per frame
	void Update () {

    }
    

    IEnumerator UpdateZ()
    {
        while(true)
        {
            curZ = Input.acceleration.z;
            if ( (lastZ - curZ > zThres || curZ - lastZ > zThres) && isBallInside )
            {
                targetObj.GetComponent<AccelInteractive>().OnAccelActive();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
            lastZ = curZ;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (isBallInside == false && col.tag == "BALL")
            isBallInside = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (isBallInside == true && col.tag == "BALL")
            isBallInside = false;
    }
}
