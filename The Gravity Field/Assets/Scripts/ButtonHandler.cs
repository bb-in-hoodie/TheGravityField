using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameObject ball;
    BallController ballController;
    FieldManager fieldManager;

    void Start()
    {
        //Get the ball's script and its controller
        ball = GameObject.Find("Ball");
        ballController = ball.GetComponent<BallController>();
        fieldManager = ball.GetComponentInChildren<FieldManager>();
    }

    void Update()
    {
        // Get keyboard input
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ballController.MoveRight();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ballController.MoveLeft();
        if (Input.GetKeyDown(KeyCode.W))
            fieldManager.ActivateWeakField();
        if (Input.GetKeyDown(KeyCode.S))
            fieldManager.ActivateStrField();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            ballController.Jump();

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            ballController.ResetMove();

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            fieldManager.DeactivateField();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked. at: " + eventData.clickTime + "/" + eventData.clickCount + "times");
        string buttonName = this.gameObject.name;

        if (buttonName == "Button_right")
            ballController.MoveRight();
        if (buttonName == "Button_left")
            ballController.MoveLeft();
        if (buttonName == "Button_gravity_weak")
            fieldManager.ActivateWeakField();
        if (buttonName == "Button_gravity_str")
            fieldManager.ActivateStrField();
        if (buttonName == "Button_jump")
            ballController.Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        string buttonName = this.gameObject.name;

        if (buttonName == "Button_gravity_str" || buttonName == "Button_gravity_weak")
            fieldManager.DeactivateField();
        else if (buttonName == "Button_right" || buttonName == "Button_left")
            ballController.ResetMove();
    }
}
