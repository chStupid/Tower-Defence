using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour {
	public float speed;
	public int damage;

    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private FootmanController footMan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
  //      currentPosition = transform.position;
  //      //Debug.Log("currentPosition: " + currentPosition);
		//if(previousPosition != currentPosition) {
  //          previousPosition = currentPosition;
  //      } else {
  //          Destroy(gameObject);
  //      }
	}
	void	OnTriggerStay(Collider other){
		if (other.tag == "Enemy" || other.tag == "QuickEnemy" || other.tag == "HeavyEnemy") {
			Vector3 angle = (other.transform.position - transform.position).normalized;
			float a = Vector3.Angle(transform.forward, angle) / 50;

			if (a > 0.1f || a < -0.1f)
				transform.forward = Vector3.Slerp (transform.forward, angle, Time.deltaTime / a); 
			else  
			{  
				speed += 2 * Time.deltaTime;  
				transform.forward = Vector3.Slerp(transform.forward, angle, 1).normalized;  
			}  

			transform.position += transform.forward * speed * Time.deltaTime;

		}
	}

    //void OnTriggerExit(Collider other) {
    //    Debug.Log("exitTrigger");
    //    Destroy(gameObject);
    //}
}
