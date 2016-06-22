using UnityEngine;
using System.Collections;

enum floorBtnState { IDLE, DOWN, UP, PRESSED }

public class FloorButtonManager : MonoBehaviour
{
    public GameObject fbInteractive;
    float yLimit = 0.09f, yAmount = 0.01f;
    Vector3 initPos;
    floorBtnState curState = floorBtnState.IDLE;

    // Use this for initialization
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (curState == floorBtnState.DOWN) // Floor button is pressed
        {
            if (initPos.y - transform.position.y < yLimit)
                transform.Translate(0, -yAmount, 0);
            else
            {
                transform.position = new Vector3(initPos.x, initPos.y - yLimit, initPos.z);
                curState = floorBtnState.PRESSED;
                OnFloorButtonPressed();
            }
        }
        else if (curState == floorBtnState.UP) // Floor button is released
        {
            if (initPos.y - transform.position.y > 0)
                transform.Translate(0, yAmount, 0);
            else
            {
                transform.position = initPos;
                curState = floorBtnState.IDLE;
                OnFloorButtonReleased();
            }
        }
    }

    void OnFloorButtonPressed()
    {
        print("Floor Button Pressed");
        if(fbInteractive != null)
            fbInteractive.GetComponent<FBInteractive>().OnFloorButtonPressed();
    }

    void OnFloorButtonReleased()
    {
        print("Floor Button Released");
        if (fbInteractive != null)
            fbInteractive.GetComponent<FBInteractive>().OnFloorButtonReleased();
    }

    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint cp in col.contacts)
        {
            if (cp.otherCollider.tag == "BALL" || cp.otherCollider.tag == "FALLING")
                curState = floorBtnState.DOWN;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "BALL" || col.collider.tag == "FALLING")
            curState = floorBtnState.UP;
    }
}
