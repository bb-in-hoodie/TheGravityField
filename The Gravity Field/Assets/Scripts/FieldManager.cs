using UnityEngine;
using System.Collections;
public enum FieldState { NORMAL, STRENGTHENED, WEAKENED  }

public class FieldManager : MonoBehaviour {
    public FieldState fieldState = FieldState.NORMAL;
    public Texture2D strTex, weakTex;
    Renderer fieldRenderer;

	// Use this for initialization
	void Start () {
        fieldRenderer = transform.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // The code in this function will be replaced with the other code soon
        if (fieldState == FieldState.NORMAL)
        {
            if (fieldRenderer.enabled == true)
                fieldRenderer.enabled = false;
        }
        else if (fieldState == FieldState.STRENGTHENED)
        {
            if (fieldRenderer.material.mainTexture == weakTex)
                fieldRenderer.material.mainTexture = strTex;
            if (fieldRenderer.enabled == false)
                fieldRenderer.enabled = true;
        }
        else if (fieldState == FieldState.WEAKENED)
        {
            if (fieldRenderer.material.mainTexture == strTex)
                fieldRenderer.material.mainTexture = weakTex;
            if (fieldRenderer.enabled == false)
                fieldRenderer.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("OnCollisionEnter : " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        print("OnCollisionExit : " + other.gameObject.name);
    }
}
