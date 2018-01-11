using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleButtonController : MonoBehaviour {
    public Transform towerSource;
    public GameObject tower;
    private GUIText goldBoard;
    private MTowerController towerScript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click() {
        towerScript = tower.GetComponent<MTowerController>();
        //Debug.Log("cost:" + towerScript.cost);
        float cost = towerScript.cost;
        goldBoard = GameObject.Find("Gold").GetComponent<GUIText>();
        float currGold = float.Parse(goldBoard.text.Substring(7));
        if (cost < currGold) {
            float newGold = currGold - cost;
            string goldText = goldBoard.text.Substring(0, 7) + newGold.ToString();
            goldBoard.text = goldText;
            Instantiate(tower, towerSource.position, towerSource.rotation);
        } else {
            Debug.Log("not enough money");
        }
    }
}
