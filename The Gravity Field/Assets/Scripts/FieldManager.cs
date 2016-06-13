﻿using UnityEngine;
using System.Collections;
public enum FieldState { NORMAL, STRENGTHENED, WEAKENED }

public class FieldManager : MonoBehaviour
{
    public Texture2D strTex, weakTex;

    FieldState fieldState = FieldState.NORMAL;
    ArrayList colList = new ArrayList();
    Renderer fieldRenderer;
    Collider col;
    GameObject ball;
    float dragAmount = 4.0f, addForceAmount = 400f;

    // Use this for initialization
    void Start()
    {
        fieldRenderer = transform.GetComponent<Renderer>();
        col = transform.GetComponent<Collider>();
        ball = transform.parent.gameObject;
        DeactivateField();
    }

    void OnTriggerEnter(Collider c)
    {
        // WEAKENED : Slow down the object, STRENGTHENED : Let the object fall down faster
        if(c.tag == "FALLING")
        {
            colList.Add(c);
            if (fieldState == FieldState.WEAKENED)
                c.GetComponent<Rigidbody>().drag = dragAmount;
            else if (fieldState == FieldState.STRENGTHENED)
                c.GetComponent<Rigidbody>().AddForce(Vector3.down * addForceAmount);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "FALLING")
        {
            colList.Remove(c);
            if (fieldState == FieldState.WEAKENED)
                c.GetComponent<Rigidbody>().drag = 0;   // Reset the speed of the object falling
        }
    }

    // Strengthened Field Activated : The texture of field is changed and visible, the collider is enabled
    public void ActivateStrField()
    {
        if (fieldState == FieldState.NORMAL)
        {
            fieldState = FieldState.STRENGTHENED;
            fieldRenderer.enabled = true;
            fieldRenderer.material.mainTexture = strTex;
            col.enabled = true;
            StartCoroutine(WaitAndDeactivate(5.0f)); // Deactivate the field after 5 sec
        }
    }

    // Weakened Field Activated : The texture of field is changed and visible, the collider is enabled
    public void ActivateWeakField()
    {
        if (fieldState == FieldState.NORMAL)
        {
            fieldState = FieldState.WEAKENED;
            fieldRenderer.enabled = true;
            fieldRenderer.material.mainTexture = weakTex;
            col.enabled = true;
            StartCoroutine(WaitAndDeactivate(5.0f)); // Deactivate the field after 5 sec
        }
    }

    // Field Deactivated : The field is no longer visible, the collider is disabled
    public void DeactivateField()
    {
        fieldState = FieldState.NORMAL;
        fieldRenderer.enabled = false;
        col.enabled = false;

        // If there are colliders in colList, set the gravity of the colliders as normal state
        if (colList.Count != 0)
        {
            foreach(Collider c in colList)
            {
                print("Delete " + c.name + " from colList");
                c.GetComponent<Rigidbody>().drag = 0;
            }
            colList.Clear();
        }
    }

    // Deactivate the field after 'waitTime' sec
    IEnumerator WaitAndDeactivate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DeactivateField();
    }
}
