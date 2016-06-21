using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour
{
    Transform respawnPoint;  
    GameManager gm;
    bool isChecked;

    // Use this for initialization
    void Start()
    {
        respawnPoint = transform.FindChild("RespawnPoint");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameObject.name == "StartPoint")
            isChecked = true;
        else
            isChecked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (isChecked == false && col.tag == "BALL")
        {
            isChecked = true;
            gm.SetLastCheckPoint(this);
        }
    }

    public Transform GetRespawnPoint() { return respawnPoint; }
}
