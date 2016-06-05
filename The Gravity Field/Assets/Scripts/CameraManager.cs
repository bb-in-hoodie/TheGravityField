using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    Vector3 gap;
    Transform ballTrans;
    // Use this for initialization
    void Start()
    {
        ballTrans = GameObject.Find("Ball").transform;
        gap = transform.position - ballTrans.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = ballTrans.position + gap;
    }
}
