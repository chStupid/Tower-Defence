using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CastleController : MonoBehaviour {
	private FootmanController normal;
    private HeavyEnemyController heavy;
    private QuickEnemyController quick;

	public GameObject explosion;
	public GameObject bloodLine;
	public float hp = 100;
	// Use this for initialization
	void Start () {
		bloodLine.GetComponent<MeshRenderer> ().material.color = Color.red;

		
	}

	// Update is called once per frame
	void Update () {
		
		if (hp <= 0) {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
		
	}
	void OnTriggerEnter(Collider other){
		// Debug.Log ("ontrigger");
		if (other.tag == "Enemy") {
			float tempHP;

			normal = GameObject.Find("Normal Enemy(Clone)").GetComponent<FootmanController> ();
			hp -= normal.damage;
			tempHP = hp / 5;
			bloodLine.transform.localScale = new Vector3 (tempHP, 2f, 0.3f);

			Destroy (other.gameObject);
		}
		if (other.tag=="HeavyEnemy") {
			float tempHP;

			heavy = GameObject.Find("Heavy Enemy(Clone)").GetComponent<HeavyEnemyController> ();
			hp -= heavy.damage;
			tempHP = hp / 5;
			bloodLine.transform.localScale = new Vector3 (tempHP, 2f, 0.3f);

			Destroy (other.gameObject);
		}
		if (other.tag=="QuickEnemy") {
			float tempHP;

			quick = GameObject.Find("Quick Enemy(Clone)").GetComponent<QuickEnemyController> ();
			hp -= quick.damage;
			tempHP = hp / 5;
			bloodLine.transform.localScale = new Vector3 (tempHP, 2f, 0.3f);

			Destroy (other.gameObject);
		}

	}
}
