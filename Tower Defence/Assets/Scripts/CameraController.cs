using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //整体移动速度
    public float speed = 5;

    ////关于鼠标滑轮的参数
    //float MouseWheelSensitivity = 0.0001f;
    //float MouseZoomMin = -2.4f;
    //float MouseZoomMax = 1.0f;
    //float normalDistance = -1.1f;

    //水平和垂直的移动速度
    public float horizontalMoveSpeed = 0.1f;
    public float verticalMoveSpeed = 0.1f;

    //上左下右的标记
    int topTag = 8;
    int leftTag = 4;
    int botTag = 2;
    int rightTag = 1;

    void Update() {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            this.gameObject.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 500));
        }
        //获取cursor坐标
        Vector3 msPos = Input.mousePosition;

        //边界最小值
        float widthBorder = Screen.width / 50;
        float heightBorder = Screen.height / 50;

        float x = 0.0f;
        float y = 0.0f;

        //当前鼠标位置标记
        int posTag = 0;

       // Debug.Log("asd" + msPos.x + " " + msPos.y);
        //不在边缘
        if (widthBorder <= msPos.x && msPos.x <= Screen.width - widthBorder &&
            heightBorder <= msPos.y && msPos.y <= Screen.height - heightBorder) {
            transform.Translate(x, y, 0);
        }
        else { //在边缘
            //  posTag
            //
            // 1100 | 1000 | 1001
            // 0100 | 0000 | 0001
            // 0110 | 0010 | 0011
            //
            // 12   |  8   |  9
            // 4    |  0   |  1
            // 6    |  2   |  3
            //
            if (msPos.y > Screen.height - heightBorder)
                posTag = posTag + topTag;
            if (msPos.x < widthBorder)
                posTag = posTag + leftTag;
            if (msPos.y < heightBorder)
                posTag = posTag + botTag;
            if (msPos.x > Screen.width - widthBorder)
                posTag = posTag + rightTag;

            switch (posTag) {
                case 0: break;
                case 1: x = horizontalMoveSpeed; break;
                case 2: y = -verticalMoveSpeed; break;
                case 3: x = horizontalMoveSpeed; y = -verticalMoveSpeed; break;
                case 4: x = -horizontalMoveSpeed; break;
                case 6: x = -horizontalMoveSpeed; y = -verticalMoveSpeed; break;
                case 8: y = verticalMoveSpeed; break;
                case 9: x = horizontalMoveSpeed; y = verticalMoveSpeed; break;
                case 12: x = -horizontalMoveSpeed; y = verticalMoveSpeed; break;
                default: break;
            }

            x *= speed * Time.deltaTime;
            y *= speed * Time.deltaTime;

            //
            transform.Translate(x, y, 0);
        }
    }
}
