using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTowerController : MonoBehaviour {
	public GameObject Missile;
	public Transform shotSpawn1,shotSpawn2;
	public float fireRate;
    public float cost;
	private float nextFire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Missile") {
			Destroy (other.gameObject);
		}
		if (other.tag == "Enemy") {
			Destroy (Missile);
		}

	}
	void OnTriggerStay(Collider other){
        //Debug.Log ("angle:");
        if (other.tag == "Enemy" || other.tag == "QuickEnemy" || other.tag == "HeavyEnemy") {
            Vector3 angle = (other.transform.position - transform.position).normalized;
            float a = Vector3.Angle(transform.forward, angle) / 50;

            if (a > 0.1f || a < -0.1f) {
                transform.forward = Vector3.Slerp(transform.forward, angle, Time.deltaTime / a);
            }
            else {
                transform.forward = Vector3.Slerp(transform.forward, angle, 1).normalized;
            }
        }

        if (Time.time > nextFire && (other.tag == "Enemy" || other.tag == "QuickEnemy" || other.tag == "HeavyEnemy")) {
			nextFire = Time.time + fireRate;

			//float angle = 180 * (float)Mathf.Atan ((other.transform.position.x - transform.position.x)/Mathf.Abs(other.transform.position.z - transform.position.z)) / (float)Mathf.PI;
			//Debug.Log ("angle" + angle);

			//transform.rotation = Quaternion.Euler (0, angle, 0);
			Instantiate(Missile,shotSpawn1.position,shotSpawn1.rotation);
			Instantiate(Missile,shotSpawn2.position,shotSpawn2.rotation);
		}

		//		if (other.tag == "Enemy") {
		//			controller.openFire ();
		//			//			Debug.Log(other.transform.position.x);
		//		}

	}
}
