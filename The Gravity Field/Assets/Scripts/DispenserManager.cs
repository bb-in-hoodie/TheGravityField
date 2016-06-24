using UnityEngine;
using System.Collections;
using System;

public class DispenserManager : MonoBehaviour, FBInteractive
{
    public GameObject targetObject;
    public float waitTime = 3.0f, startTime = 0.0f;
    public bool shootOnFBPressed = false, onlyOne = true;

    Transform targetPoint;
    GameObject oldObj = null;
    bool shouldStop = false;

    // Use this for initialization
    void Start()
    {
        targetPoint = transform.FindChild("TargetPoint");
        if (shootOnFBPressed)
            shouldStop = true;
        
        if (shootOnFBPressed == false && targetObject != null)
            StartCoroutine("CreateObject");
    }
    

    IEnumerator CreateObject()
    {
        yield return new WaitForSeconds(startTime);
        while (shouldStop == false)
        {
            GameObject newObj = (GameObject)Instantiate(targetObject, targetPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            if (shouldStop == false && onlyOne == true)
                Destroy(newObj);
        }
    }

    void ShootOnce()
    {
        if(oldObj != null)
            Destroy(oldObj);

        oldObj = (GameObject)Instantiate(targetObject, targetPoint.position, Quaternion.identity);
    }

    public void OnFloorButtonPressed()
    {
        if (shootOnFBPressed)  // If shootOnFBPressed is true, dispenser shoot the target only when the floor button is pressed
        {
            shouldStop = false;
            if (waitTime == -1)
                ShootOnce();
            else
                StartCoroutine("CreateObject");
        }
        else  // If shootOnFBPressed is false and FB is pressed, It means that dispenser doesn't have to shoot the target anymore
        {
            shouldStop = true;
        }
    }

    public void OnFloorButtonReleased()
    {
        if (shootOnFBPressed)
            shouldStop = true;
    }
}
