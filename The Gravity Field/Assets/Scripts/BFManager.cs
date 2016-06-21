using UnityEngine;
using System.Collections;

public class BFManager : MonoBehaviour {
    float alpha = 1.0f;
    bool doDestroy = false;

    void FixedUpdate()
    {
        if(doDestroy)
        {
            if (alpha >= 0)
            {
                alpha -= 0.01f;
                Color oldColor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
            }
            else
                Destroy(gameObject);
        }
    }

    IEnumerator DestroyBF()
    {
        transform.parent = null;
        yield return new WaitForSeconds(3.0f);
        doDestroy = true;
    }
}
