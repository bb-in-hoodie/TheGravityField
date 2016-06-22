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

    // Use this for initialization
    void Start()
    {
        targetPoint = transform.FindChild("TargetPoint");

        if (targetObject != null)
            StartCoroutine("CreateObject");
    }
   
    IEnumerator CreateObject()
    {
        while(shouldStop == false)
        {
            GameObject newObj = (GameObject) Instantiate(targetObject, targetPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            if (shouldStop == false)
                Destroy(newObj);
        }
    }
/*
    public void OnFloorButtonPressed()
    {
        if (shootOnFBPressed)  // If shootOnFBPressed is true, dispenser shoot the target only when the floor button is pressed
        {
            shouldStop = false;
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
    */
}
