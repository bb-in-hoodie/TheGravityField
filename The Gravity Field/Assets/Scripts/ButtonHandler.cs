using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public void OnPointerDown (PointerEventData eventData) 
	{
		Debug.Log (this.gameObject.name + " Was Clicked. at: " + eventData.clickTime + "/" + eventData.clickCount + "times");
		
		GameObject ball = GameObject.Find("Ball");
		
		Debug.Log(ball.name + " found at OnPointerDown");
		
		//Get the ball's script
		BallController linkToScript = (BallController) ball.GetComponent(typeof(BallController));
		linkToScript.moveRight();
	}

	public void OnPointerUp (PointerEventData eventData) 
	{
		Debug.Log (this.gameObject.name + " Was Released.");
		
		GameObject ball = GameObject.Find("Ball");
		
		Debug.Log(ball.name + " found at OnPointerUp");
		
		//Get the ball's script
		BallController linkToScript = (BallController) ball.GetComponent(typeof(BallController));
		linkToScript.resetMove();
	}	
}
