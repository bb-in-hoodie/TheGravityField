using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public string nextLevel;
    Transform ball;
    CheckPointManager lastCheckPoint;

    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        lastCheckPoint = GameObject.Find("StartPoint").GetComponent<CheckPointManager>();
        ball = GameObject.Find("Ball").transform;
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

    public void Clear() { StartCoroutine("LoadNextScene"); }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevel);
    }

    public void SetLastCheckPoint(CheckPointManager cpm) { lastCheckPoint = cpm; }
}
