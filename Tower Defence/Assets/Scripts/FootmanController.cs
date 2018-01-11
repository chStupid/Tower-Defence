using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootmanController : MonoBehaviour {

    public float speed;         // 速度
    public float damage;        // 伤害值
    public float healthPoint;   // 血条
    public float value;    		// 价值
    public GameObject target;   // 移动目标(朝着城堡移动)
	public GameObject explosionEnemy;// 敌人爆炸
	public GameObject explosionBolt; // 子弹爆炸

	private GUIText wave;		// 回合数
	private GUIText goldBoard;	// 金币板
	private float halfSpeed;	// 半速
	private BoltMover bolt;		// 子弹对象
    private MissileMover missile; //子弹对象
    private Vector3 movement;   // 用来储存生成敌人时判断的移动方向
	private Vector3 direction;  // 方向

	private float x;
	private float z;
	private float xToMove;
	private float zToMove;
	private float eVector;

    void Start() {
		this.speed = speed;
		halfSpeed = this.speed / 2;
		healthPoint += int.Parse (this.getWave ().Substring (7)) * 12;
    }

	string getWave () {
		wave = GameObject.Find("Wave").GetComponent<GUIText>();
		return wave.text;
	}

    void Update() {
		x = gameObject.transform.position.x;
		z = gameObject.transform.position.z;
		xToMove = target.transform.position.x - x;
		zToMove = target.transform.position.z - z;
		eVector = Mathf.Sqrt (xToMove * xToMove + zToMove * zToMove);
		movement = new Vector3(xToMove / eVector,
			0.0f,
			zToMove / eVector);
        GetComponent<Rigidbody>().velocity = movement * speed * 5;  


    }

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Bolt") {
			bolt = GameObject.Find ("bolt(Clone)").GetComponent<BoltMover> ();
			goldBoard = GameObject.Find ("Gold").GetComponent<GUIText> ();
			healthPoint -= bolt.damage;
			if (healthPoint <= 0) {
				Destroy (this.gameObject);
				float newGold = float.Parse(goldBoard.text.Substring (7)) + this.value;
				string goldText = goldBoard.text.Substring (0, 7) + newGold.ToString();
				goldBoard.text = goldText;
				GameObject tmp = Instantiate (explosionEnemy, transform.position, transform.rotation) as GameObject;
				Destroy (tmp, 1);
			}
			Destroy (other.gameObject);
			GameObject tmp2 = Instantiate (explosionBolt, transform.position, transform.rotation) as GameObject;
			Destroy (tmp2, 1);
		}
        if (other.tag == "Missile") {
            missile = GameObject.Find("Missile(Clone)").GetComponent<MissileMover>();
            goldBoard = GameObject.Find("Gold").GetComponent<GUIText>();
            healthPoint -= missile.damage;
            if (healthPoint <= 0) {
                Destroy(this.gameObject);
                float newGold = float.Parse(goldBoard.text.Substring(7)) + this.value;
                string goldText = goldBoard.text.Substring(0, 7) + newGold.ToString();
                goldBoard.text = goldText;
                GameObject tmp = Instantiate(explosionEnemy, transform.position, transform.rotation) as GameObject;
                Destroy(tmp, 1);
            }
            Destroy(other.gameObject);
            GameObject tmp2 = Instantiate(explosionBolt, transform.position, transform.rotation) as GameObject;
            Destroy(tmp2, 1);
        }

    }

	void OnTriggerStay(Collider other) {
		if (other.tag == "Turret") {
			this.speed = halfSpeed;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Turret") {
			this.speed = halfSpeed * 2;
		}
	}
}
