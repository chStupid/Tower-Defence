using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {
	public float speed;
	public int damage;
	public GameObject target;


	// Use this for initialization
	void Start () {
		//transform.position += transform.up * speed * Time.deltaTime; 
		//GetComponent<Rigidbody> ().velocity = transform.up * speed;

	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void OnTriggerStay(Collider other){
		if ((other.tag == "Enemy" || other.tag == "QuickEnemy" || other.tag == "HeavyEnemy")) {
			
			Vector3 angle = (other.transform.position - transform.position).normalized;
			float a = Vector3.Angle(transform.up, angle) / 50;

			if (a > 0.1f || a < -0.1f)
				transform.up = Vector3.Slerp (transform.up, angle, Time.deltaTime / a); 
			else  
			{  
				speed += 2 * Time.deltaTime;  
				transform.up = Vector3.Slerp(transform.up, angle, 1).normalized;  
			}  

			transform.position += transform.up * speed * Time.deltaTime;
			if (other.transform.position == null) {
				Destroy (gameObject);
			}
		}

	
	}

}
