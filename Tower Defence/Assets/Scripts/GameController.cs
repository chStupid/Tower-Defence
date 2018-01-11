using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GUIText GameTime;
    public GUIText Wave;
    public GUIText Gold;
    public GUIText EndText;
    public GameObject QuickEnemy;
    public GameObject HeavyEnemy;
    public GameObject NormalEnemy;
    public Transform North;
   // public Transform Sourth;
    public Transform East;
    public Transform West;
    public int salary;  //the amount of glod player get per second   // 5gold / second
    public int waveInterval; //Interval of wave
    public GameObject castle;

    private bool isStart;           // true start game
    private float timeSpend;        // time spend from game start to now
    private int minute;
    private int second;
    private int gold;
    private int whenAddGold;        // 5gold / second
    private int wave;
    private int whenAddWave;        // 1 wave of enemy / minute
    private int whereAddEnemy;      // ramdom 0-3 decide north south east or west
    private float fireRate;
    private float nextFire;

    // Use this for initialization

    //*********The part below⤵️ are paramaters announcement by JZY, do not edit it without permission*********//
    private int inRate = 10;                    //the speed for enemy in the range of tower(ROT)
    private int outRate = 20;                   //the speed for enemy out the range of tower(ROT)
    private bool isFire = false;                //used to judge whether the tower should fire;
                                                //private bool isEnter = false;				//used to judge whether the enemy entered the ROT
    private float EnemyX;
    private float EnemyZ;
    private int whichEnemy;

    //*********The part above⤴️ are paramaters announcement by JZY, do not edit it without permission*********//
    void Start() {
        isStart = true;
        timeSpend = 0.0f;
        minute = 0;
        second = 0;
        whenAddGold = 1;
        whenAddWave = 0;
        whichEnemy = 0;

        GameTime.text = "Time : 0:0";
        Gold.text = "Gold : 350";
        Wave.text = "Wave : 0";
        gold = 0;
        wave = 0;

        fireRate = 1;

        EndText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (isStart) {
            timeSpend += Time.deltaTime;
            minute = (int)timeSpend / 60;
            second = (int)timeSpend - minute * 60;
            GameTime.text = "Time : " + minute + ":" + second;
            if ((int)timeSpend == whenAddGold) {
                whenAddGold += 1;
                whenAddWave += 1;
                //	gold = second* salary;
                //	Gold.text = "Gold : " + gold;
                Gold.text = "Gold : " + (float.Parse(Gold.text.Substring(7)) + salary);
            }
            if (waveInterval == whenAddWave) {
                // or enemy all die , 10s later new wave
                whenAddWave = 0;
                wave += 1;
                Wave.text = "Wave : " + wave;
                //改成只有三个方向
                whichEnemy = Random.Range(1, 4);  
                whereAddEnemy = Random.Range(0, 3);
                InstantiateEnemy(whichEnemy, whereAddEnemy);
            }

            if(castle == null) {
                Debug.Log("Game Over");
                isStart = false;
            }
        } else {
            EndText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) {
                Scene level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(level.name);
            }
        }
    }

    public void InstantiateEnemy(int who, int where) {
        Vector3 offsetNorthorSourth = new Vector3(5, 0, 0);
        Vector3 offsetEastorWest = new Vector3(0, 0, 5);
        Quaternion rotation = Quaternion.identity;
        if (who == 1) {
            if (where == 0) {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                Instantiate(QuickEnemy, North.position, rotation);
                Instantiate(QuickEnemy, North.position + offsetNorthorSourth, rotation);
                Instantiate(QuickEnemy, North.position - offsetNorthorSourth, rotation);
            //} else if (where == 1) {
            //    Instantiate(QuickEnemy, Sourth.position, Sourth.rotation);
            //    Instantiate(QuickEnemy, Sourth.position + offsetNorthorSourth, Sourth.rotation);
            //    Instantiate(QuickEnemy, Sourth.position - offsetNorthorSourth, Sourth.rotation);
            } else if (where == 2) {
                rotation.eulerAngles = new Vector3(0, -90, 0);
                Instantiate(QuickEnemy, East.position, rotation);
                Instantiate(QuickEnemy, East.position + offsetEastorWest, rotation);
                Instantiate(QuickEnemy, East.position - offsetEastorWest, rotation);
            } else {
                rotation.eulerAngles = new Vector3(0, 90, 0);
                Instantiate(QuickEnemy, West.position, rotation);
                Instantiate(QuickEnemy, West.position + offsetEastorWest, rotation);
                Instantiate(QuickEnemy, West.position - offsetEastorWest, rotation);
            }
        } else if (who == 2) {
            if (where == 0) {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                Instantiate(HeavyEnemy, North.position, rotation);

            //} else if (where == 1) {
            //    Instantiate(HeavyEnemy, Sourth.position, Sourth.rotation);
            } else if (where == 2) {
                rotation.eulerAngles = new Vector3(0, -90, 0);
                Instantiate(HeavyEnemy, East.position, rotation);
            } else {
                rotation.eulerAngles = new Vector3(0, 90, 0);
                Instantiate(HeavyEnemy, West.position, rotation);
            }
        } else {
            if (where == 0) {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                Instantiate(NormalEnemy, North.position, rotation);
                Instantiate(NormalEnemy, North.position + offsetNorthorSourth, rotation);
            //} else if (where == 1) {
            //    Instantiate(NormalEnemy, Sourth.position, Sourth.rotation);
            //    Instantiate(NormalEnemy, Sourth.position + offsetNorthorSourth, Sourth.rotation);

            } else if (where == 2) {
                rotation.eulerAngles = new Vector3(0, -90, 0);
                Instantiate(NormalEnemy, East.position, rotation);
                Instantiate(NormalEnemy, East.position + offsetEastorWest, rotation);

            } else {
                rotation.eulerAngles = new Vector3(0, 90, 0);
                Instantiate(NormalEnemy, West.position, rotation);
                Instantiate(NormalEnemy, West.position + offsetEastorWest, rotation);

            }
        }
    }

    //***********The part below⤵️ are functions written by JZY, do not edit it without permission***********//
    public bool getIsFire() {
        return isFire;
    }
    public int getInRate() {
        return inRate;
    }
    public int getOutRate() {
        return outRate;
    }
    public void openFire() {
        isFire = true;
    }
    public void stopFire() {
        isFire = false;
    }
    public float getEX() {
        return EnemyX;
    }
    public float getEZ() {
        return EnemyZ;
    }
    public void setEX(float x) {
        EnemyX = x;
    }
    public void setEZ(float z) {
        EnemyX = z;
    }

    //***********The part above⤴️ are functions written by JZY, do not edit it without permission***********//
}
