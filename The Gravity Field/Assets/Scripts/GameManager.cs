using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    Transform ball;
    CheckPointManager lastCheckPoint;

    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        lastCheckPoint = GameObject.Find("StartPoint").GetComponent<CheckPointManager>();
        ball = GameObject.Find("Ball").transform;
        ball.position = lastCheckPoint.GetRespawnPoint().position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnBall()
    {
        ball.position = lastCheckPoint.GetRespawnPoint().position;
        ball.GetComponent<Renderer>().enabled = true;
    }

    public void Clear()
    {
        print("Clear");
    }

    public void SetLastCheckPoint(CheckPointManager cpm) { lastCheckPoint = cpm; }
}
