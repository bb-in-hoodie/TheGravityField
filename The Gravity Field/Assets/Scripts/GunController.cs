using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
	void Update () {
	    if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
	}
}
