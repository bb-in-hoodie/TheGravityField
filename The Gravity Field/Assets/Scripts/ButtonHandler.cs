﻿using UnityEngine;
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

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked. at: " + eventData.clickTime + "/" + eventData.clickCount + "times");
        string buttonName = this.gameObject.name;

        if (buttonName == "Button_right")
            ballController.MoveRight();
        if (buttonName == "Button_left")
            ballController.MoveLeft();
        if (buttonName == "Button_gravity_up")
            fieldManager.ActivateWeakField();
        if (buttonName == "Button_gravity_down")
            fieldManager.ActivateStrField();
        if (buttonName == "Button_jump")
            ballController.Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ballController.ResetMove();
    }
}
