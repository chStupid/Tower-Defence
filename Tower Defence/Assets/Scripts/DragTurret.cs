using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;

public class DragTurret : MonoBehaviour {
    public Transform towerSource;
    private int canDrag;
    private GUIText errorMessage; 	//show illegal movement of turret
    // Use this for initialization  
    void Start() {
        canDrag = 1;
        errorMessage = GameObject.Find("Error").GetComponent<GUIText>();
        errorMessage.text = "";
        //errorMessage.gameObject.SetActive(false);
        //errorMessage.text = "illegal position for turret !";
    }

    // Update is called once per frame  
    void Update() {

    }

    IEnumerator OnMouseDown() {
        if (canDrag == 1) {
            // errorMessage.gameObject.SetActive(false);
            errorMessage = GameObject.Find("Error").GetComponent<GUIText>();
            errorMessage.text = "";
            Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
            var offset = transform.position - Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x,
                            Input.mousePosition.y,
                            screenSpace.z));
            while (Input.GetMouseButton(0)) {
                Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
                //Debug.Log(curPosition.x+", "+curPosition.y);
                transform.position = curPosition;
                yield return new WaitForFixedUpdate();
            }
            //第二象限 horizontal
            if (transform.position.x < -16.3 && transform.position.x > -78 && transform.position.z < 13 && transform.position.z > 5) {
                canDrag = 0;
            }
            //第二象限 vertical
            else if (transform.position.x < -16.3 && transform.position.x > -30 && transform.position.z < 69 && transform.position.z > 5) {
                canDrag = 0;
            }
            //第一象限 horizontal
            else if (transform.position.x < 67 && transform.position.x > 11 && transform.position.z < 13 && transform.position.z > 5) {
                //					右上角x					左下角x						右上角y						
                canDrag = 0;
            }
            //第一象限 vertical
             else if (transform.position.x < 21 && transform.position.x > 11 && transform.position.z < 69 && transform.position.z > 5) {
                canDrag = 0;
            }
            //第三象限 horizontal
            else if (transform.position.x < -16.3 && transform.position.x > -78 && transform.position.z < -11 && transform.position.z > -19) {
                canDrag = 0;
            }
            //第三象限  vertical
            else if (transform.position.x < -16.3 && transform.position.x > -27 && transform.position.z < -11 && transform.position.z > -44) {
                canDrag = 0;
            }
            //第四象限 horizontal
                else if (transform.position.x < 67 && transform.position.x > 11 && transform.position.z < -11 && transform.position.z > -19) {
                canDrag = 0;
            }
            //第四象限  vertical
            else if (transform.position.x < 21 && transform.position.x > 11 && transform.position.z < -11 && transform.position.z > -44) {
                canDrag = 0;
            } else {
                transform.position = new Vector3(towerSource.position.x, towerSource.position.y, towerSource.position.z);

                errorMessage = GameObject.Find("Error").GetComponent<GUIText>();
                errorMessage.text = "illegal position for turret !";
            }

        }
    }
}