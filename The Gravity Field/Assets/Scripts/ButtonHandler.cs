using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked. at: " + eventData.clickTime + "/" + eventData.clickCount + "times");
        string buttonName = this.gameObject.name;

        GameObject ball = GameObject.Find("Ball");
        Debug.Log(ball.name + " found at OnPointerDown");

        //Get the ball's script
        BallController linkToScript = (BallController)ball.GetComponent(typeof(BallController));

        if (buttonName == "Button_right")
            linkToScript.moveRight();
        if (buttonName == "Button_left")
            linkToScript.moveLeft();
        if (buttonName == "Button_gravity_up")
            ; //Here goes function increasing gravity
        if (buttonName == "Button_gravity_down")
            ; //Here goes function decreasing gravity
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Released.");

        GameObject ball = GameObject.Find("Ball");

        Debug.Log(ball.name + " found at OnPointerUp");

        //Get the ball's script
        BallController linkToScript = (BallController)ball.GetComponent(typeof(BallController));
        linkToScript.resetMove();
    }
}
