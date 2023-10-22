using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInCharaMake : MonoBehaviour
{
    private Camera mainCam; //カメラ
    [SerializeField] private GameObject model;  // モデル
    private void Start()
    {
        mainCam = Camera.main; 
    }
    // タイトルボタンが押されたとき
    public void OnClickTitleButton()
    {
        Title.isUpdate = true; // タイトルのキャラメイクオブジェクトの更新フラグ
        SceneController.SceneChange("Title");
    }
    // リセットボタンが押されたとき
    public void OnClickResetButton()
    {
        mainCam.fieldOfView = ViewControl.maxFieldOfView;   //拡大率のリセット
        
        model.transform.rotation = Quaternion.Euler(0, ViewControl.baseRotateY, 0); //回転のリセット
        ViewControl.rotateY = ViewControl.baseRotateY;
        model.transform.position = new Vector3(ViewControl.basePosX, ViewControl.basePosY, -7); //移動のリセット
        ViewControl.posX = ViewControl.basePosX;
        ViewControl.posY = ViewControl.basePosY;

    }
}
