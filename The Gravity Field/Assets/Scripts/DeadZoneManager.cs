using UnityEngine;
using System.Collections;

public class DeadZoneManager : MonoBehaviour
{
    GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision col)
    {
        foreach(ContactPoint cp in col.contacts)
        {
            if (cp.otherCollider.tag == "BALL")
                cp.otherCollider.gameObject.GetComponent<BallController>().Dead();
        }
    }
}
