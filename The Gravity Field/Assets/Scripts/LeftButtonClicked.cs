using UnityEngine;
using System.Collections;

public class LeftButtonClicked : MonoBehaviour {

    // Use this for initialization

    // Update is called once per frame
        public void clicked() {
            foreach (Transform child in transform)
            {
                child.position += Vector3.up * 10.0F;
            }
        }

}
