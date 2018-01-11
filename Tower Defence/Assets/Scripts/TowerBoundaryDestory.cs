using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBoundaryDestory : MonoBehaviour {
	//public GameObject shotSpawn;

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
		
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Bolt") {
			Destroy (other.gameObject);
		}
//		if (other.tag == "Enemy") {
//			controller.stopFire ();
//
//		}
	}
//	void OnTriggerEnter(Collider other){
//		if (other.tag == "Enemy") {
//			controller.openFire ();
//		}
//	
//	}
//	void OnTriggerStay(Collider other){
//		if (other.tag == "Enemy") {
//			controller.openFire ();
////			Debug.Log(other.transform.position.x);
//		}
//	
//	}
}
