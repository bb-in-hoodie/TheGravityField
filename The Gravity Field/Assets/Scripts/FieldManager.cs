using UnityEngine;
using System.Collections;
public enum FieldState { NORMAL, STRENGTHENED, WEAKENED }

public class FieldManager : MonoBehaviour
{
    public Texture2D strTex, weakTex;

    FieldState fieldState = FieldState.NORMAL;
    Renderer fieldRenderer;
    Collider collider;

    // Use this for initialization
    void Start()
    {
        fieldRenderer = transform.GetComponent<Renderer>();
        collider = transform.GetComponent<Collider>();
        DeactivateField();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "FALLING")
        {
            print("Gravity Field - OnCollisionEnter : " + c.gameObject.name);
            c.GetComponent<Rigidbody>().drag = 5;
        }
    }

    void OnTriggerExit(Collider c)
    {
        print("Gravity Field - OnCollisionExit : " + c.gameObject.name);
    }

    // Strengthened Field Activated : The texture of field is changed and visible, the collider is enabled
    public void ActivateStrField()
    {
        if (fieldState == FieldState.NORMAL)
        {
            fieldState = FieldState.STRENGTHENED;
            fieldRenderer.enabled = true;
            fieldRenderer.material.mainTexture = strTex;
            collider.enabled = true;
            StartCoroutine(WaitAndDeactivate(5.0f)); // Deactivate the field after 5 sec
        }
    }

    // Weakened Field Activated : The texture of field is changed and visible, the collider is enabled
    public void ActivateWeakField()
    {
        if (fieldState == FieldState.NORMAL)
        {
            fieldState = FieldState.WEAKENED;
            fieldRenderer.enabled = true;
            fieldRenderer.material.mainTexture = weakTex;
            collider.enabled = true;
            StartCoroutine(WaitAndDeactivate(5.0f)); // Deactivate the field after 5 sec
        }
    }

    // Field Deactivated : The field is no longer visible, the collider is disabled
    public void DeactivateField()
    {
        fieldState = FieldState.NORMAL;
        fieldRenderer.enabled = false;
        collider.enabled = false;
    }

    // Deactivate the field after 'waitTime' sec
    IEnumerator WaitAndDeactivate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DeactivateField();
    }
}
