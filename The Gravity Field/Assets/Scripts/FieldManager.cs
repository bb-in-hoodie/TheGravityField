using UnityEngine;
using System.Collections;
public enum FieldState { NORMAL, STRENGTHENED, WEAKENED }

public class FieldManager : MonoBehaviour
{
    public Texture2D strTex, weakTex;
    public FieldState fieldState = FieldState.NORMAL;
    ArrayList colList = new ArrayList();
    Renderer fieldRenderer;
    Collider col;
    GameObject ball;
    float dragAmount = 4.0f, addForceAmount = 400f;
    float normalG = 0.0f, weakG = 4f, strG = -6f;

    // Use this for initialization
    void Start()
    {
        fieldRenderer = transform.GetComponent<Renderer>();
        col = transform.GetComponent<Collider>();
        ball = transform.parent.gameObject;
        DeactivateField();
    }

    void OnTriggerEnter(Collider c)
    {
        // WEAKENED : Slow down the object, STRENGTHENED : Let the object fall down faster
        if (c.tag == "FALLING")
        {
            colList.Add(c);
            if (fieldState == FieldState.WEAKENED)
                c.GetComponent<Rigidbody>().drag = dragAmount;
            else if (fieldState == FieldState.STRENGTHENED)
                c.GetComponent<Rigidbody>().AddForce(Vector3.down * addForceAmount);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "FALLING")
        {
            colList.Remove(c);
            if (fieldState == FieldState.WEAKENED)
                c.GetComponent<Rigidbody>().drag = 0;   // Reset the speed of the object falling
        }
    }

    // Strengthened Field Activated : The texture of field is changed and visible, the collider is enabled
    public void ActivateStrField()
    {
        if (fieldState == FieldState.NORMAL)
        {
            fieldState = FieldState.STRENGTHENED;
            fieldRenderer.enabled = true;
            fieldRenderer.material.mainTexture = strTex;
            ball.GetComponent<BallController>().SetMaterial(2);
            col.enabled = true;
            ball.GetComponent<BallController>().SetRelativeForce(new Vector3(0, strG, 0));
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
            ball.GetComponent<BallController>().SetMaterial(1);
            col.enabled = true;
            ball.GetComponent<BallController>().SetRelativeForce(new Vector3(0, weakG, 0));
        }
    }

    // Field Deactivated : The field is no longer visible, the collider is disabled
    public void DeactivateField()
    {
        fieldState = FieldState.NORMAL;
        fieldRenderer.enabled = false;
        col.enabled = false;
        ball.GetComponent<BallController>().SetRelativeForce(new Vector3(0, normalG, 0));

        // If there are colliders in colList, set the gravity of the colliders as normal state
        if (colList.Count != 0)
        {
            foreach (Collider c in colList)
            {
                print("Delete " + c.name + " from colList");
                c.GetComponent<Rigidbody>().drag = 0;
            }
            colList.Clear();
        }
        ball.GetComponent<BallController>().SetMaterial(0);
    }
}
