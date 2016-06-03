using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler {
	
	// Use this for initialization
	/*
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	*/

	public void OnPointerDown (PointerEventData eventData) 
	{
		Debug.Log (this.gameObject.name + " Was Clicked. at: " + eventData.clickTime + "/" + eventData.clickCount + "times");
		
		GameObject ball = GameObject.Find("Ball");
		
		Debug.Log(ball.name + " found");
		
		//Get the ball's script
		BallController linkToScript = (BallController) ball.GetComponent(typeof(BallController));
		linkToScript.moveLeft();
	}	

}
