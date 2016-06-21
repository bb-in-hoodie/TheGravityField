using UnityEngine;
using System.Collections;

public class GoalPointManager : MonoBehaviour
{
    GameManager gm;
    Canvas canvas;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "BALL")
        {
            canvas.enabled = false;
            col.gameObject.SetActive(false);
            gm.Clear();
        }
    }
}
