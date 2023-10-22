using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInZukan : MonoBehaviour
{
    [SerializeField] private Transform itemParent; //衣服の親
    // タイトルボタンが押されたとき
    public void OnClickTitleButton()
    {
        Title.isUpdate = true; // タイトルのキャラメイクオブジェクトの更新フラグ
        SceneController.SceneChange("Title");
    }
    // リセットボタンが押されたとき
    public void OnClickResetButton()
    {
        itemParent.rotation = Quaternion.Euler(0, ZukanViewController.baseRotateY, 0);
        ZukanViewController.rotateY = ZukanViewController.baseRotateY;
    }
}
