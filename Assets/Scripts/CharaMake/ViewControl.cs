using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ViewControl : MonoBehaviour
{
    private Camera mainCam; //カメラ
    public static float maxFieldOfView = 60.0f;
    public static float minFieldOfView = 20.0f;

    public static float baseRotateY = 176.0f;
    public static float rotateY = 176.0f;

    public static float basePosX = -0.5f;
    public static float basePosY = -0.1f;
    public static float posX = -0.5f;
    public static float posY = -0.1f;

    private float upperFrame = -1.9f;
    private float lowerFrame = 1.0f;
    private float rightFrame =-1.5f;
    private float leftFrame = 0.2f;

    [SerializeField] private GameObject model;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        // スクロールビュー外で拡大縮小
        if (!(505 <= mousePos.x && mousePos.x <= 780 && 5 <= mousePos.y && mousePos.y <= 435))
        {
            //ホイールを取得して、均しのためにtime.deltaTimeをかけておく
            var scroll = Input.mouseScrollDelta.y * Time.deltaTime * 1200;
            mainCam.fieldOfView -= scroll;

            if (mainCam.fieldOfView <= minFieldOfView)
            {
                mainCam.fieldOfView = minFieldOfView;
            }
            else if (mainCam.fieldOfView >= maxFieldOfView)
            {
                mainCam.fieldOfView = maxFieldOfView;
            }
            else
            {
                mainCam.transform.position = new Vector3(-(maxFieldOfView - mainCam.fieldOfView) / 150, 1, -10);
            }
        }
        

        // 左クリックしているなら(Y軸中心回転)
        if (Input.GetMouseButton(0))
        {
            float moveLen = Input.GetAxis("Mouse X") * Time.deltaTime * 6000;
            rotateY -= moveLen;
            model.transform.rotation = Quaternion.Euler(0, rotateY, 0);
        }
        // 右クリックしているなら(上下左右移動)
        if (Input.GetMouseButton(1))
        {
            float moveLenX = Input.GetAxis("Mouse X") * Time.deltaTime * 8;
            float moveLenY = Input.GetAxis("Mouse Y") * Time.deltaTime * 8;
            posX -= moveLenX;
            posY -= moveLenY;
            if(posY <= upperFrame)
            {
                posY = upperFrame;
            }
            else if(posY >= lowerFrame)
            {
                posY = lowerFrame;
            }
            if (posX <= rightFrame)
            {
                posX = rightFrame;
            }
            else if (posX >= leftFrame)
            {
                posX = leftFrame;
            }
            model.transform.position = new Vector3(posX, posY, -7);
        }
    }

}
