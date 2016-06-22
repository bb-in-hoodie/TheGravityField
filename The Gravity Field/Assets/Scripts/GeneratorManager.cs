using UnityEngine;
using System.Collections;
using System;

public class GeneratorManager : MonoBehaviour
{
    public GameObject targetObject;
    public float waitTime = 3.0f;
    //public bool shootOnFBPressed = false;

    Transform targetPoint;
    public bool shouldStop = true;
    bool prevState = true;
    bool mutexLock = false;
    
    // Use this for initialization
    void Start()
    {
        targetPoint = transform.FindChild("TargetPoint");
    }

    void FixedUpdate()
    {
    	if(shouldStop != prevState)
    	{
            if (targetObject != null)
                StartCoroutine("CreateObject"); 
            prevState = shouldStop;
    	}
    }

    IEnumerator CreateObject()
    {

        if(mutexLock == false)
        {
            mutexLock = true;
        
            if(shouldStop == false)
            {
            	yield return new WaitForSeconds(waitTime);
                GameObject newObj = (GameObject) Instantiate(targetObject, targetPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(waitTime);
                Destroy(newObj);
            }

            mutexLock = false;
        }
        else
        {
            Debug.Log("Mutex lock");
        }

    }

   

}
