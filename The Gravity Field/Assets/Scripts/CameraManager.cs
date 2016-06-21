using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    float verFollow = 0.1f, horFollow = 0.2f, yGap = 0.15f,  zGap = -30.0f;
    Transform ballTrans;

    // Use this for initialization
    void Start()
    {
        ballTrans = GameObject.Find("Ball").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xVec = Mathf.Lerp(transform.position.x, ballTrans.position.x, verFollow);
        float yVec = Mathf.Lerp(transform.position.y, ballTrans.position.y, horFollow);
        transform.position = new Vector3(xVec, yVec + yGap, zGap);
    }
}
