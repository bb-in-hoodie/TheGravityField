using UnityEngine;
using System.Collections;
using System;

public class DoorManager : MonoBehaviour, FBInteractive
{
    public Material idleMat, deactivMat;
    Collider col;
    Renderer ren;

    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider>();
        ren = GetComponent<Renderer>();
        ren.material = idleMat;
    }
    
    public void OnFloorButtonPressed()
    {
        ren.material = deactivMat;
        col.enabled = false;
    }

    public void OnFloorButtonReleased()
    {
        ren.material = idleMat;
        col.enabled = true;
    }
}
