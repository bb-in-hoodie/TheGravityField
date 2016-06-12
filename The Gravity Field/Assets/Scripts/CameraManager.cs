using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    float hoverAmount = 1.70f;
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
        transform.position = ballTrans.position + gap + Vector3.up* hoverAmount;
    }
}
