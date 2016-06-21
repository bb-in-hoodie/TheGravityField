using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    float verFollow = 3.0f, horFollow = 10.0f, yGap = 0.15f,  zGap = -30.0f;
    Transform ballTrans;

    // Use this for initialization
    void Start()
    {
        ballTrans = GameObject.Find("Ball").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xVec = Mathf.Lerp(transform.position.x, ballTrans.position.x, Time.deltaTime * verFollow);
        float yVec = Mathf.Lerp(transform.position.y, ballTrans.position.y, Time.deltaTime * horFollow);
        transform.position = new Vector3(xVec, yVec + yGap, zGap);
    }
}
