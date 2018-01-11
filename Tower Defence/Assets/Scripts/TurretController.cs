using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
	public GameObject bolt;
	public Transform shotSpawn;
	public float fireRate;
    public float cost;
	private float nextFire;
	private GameController controller;
	// Use this for initialization
	void Start () {
		GameObject tmp = GameObject.FindGameObjectWithTag ("GameController");
		controller = tmp.GetComponent<GameController> ();
		if (controller == null) {
			Debug.LogError ("Unable to find the GameController Script");
		}

	}
	
	// Update is called once per frame
	void Update () {
//		if (Time.time > nextFire&&controller.getIsFire()) {
//			nextFire = Time.time + fireRate;
//			shotSpawn.transform.rotation = Quaternion.Euler (0, 0, 90);
//			Instantiate (bolt, shotSpawn.position, shotSpawn.rotation);
//	//		Debug.Log (shotSpawn.transform.rotation.z);
//		}
	
	}

	void OnTriggerStay(Collider other){
		//Debug.Log ("angle:");
        if(other.tag == "Enemy" || other.tag == "QuickEnemy" || other.tag == "HeavyEnemy") {
            Vector3 angle = (other.transform.position - transform.position).normalized;
            float a = Vector3.Angle(transform.forward, angle) / 50 ;

            if(a > 0.1f || a < -0.1f) {
                transform.forward = Vector3.Slerp(transform.forward, angle, Time.deltaTime / a);
            } else {
                transform.forward = Vector3.Slerp(transform.forward, angle, 1).normalized;
            }
        }

		if (Time.time > nextFire && (other.tag == "Enemy" || other.tag == "QuickEnemy" || other.tag == "HeavyEnemy")) {
            nextFire = Time.time + fireRate;
			//float angle = 180 * (float)Mathf.Atan ((other.transform.position.x - transform.position.x)/Mathf.Abs(other.transform.position.z - transform.position.z)) / (float)Mathf.PI
			//shotSpawn.transform.rotation = Quaternion.Euler (90, angle, 0);
			Instantiate(bolt,shotSpawn.position,shotSpawn.rotation);
		}
	}

	void OnTriggerExit(Collider other){

	}
}
