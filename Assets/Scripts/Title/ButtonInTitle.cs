using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInTitle : MonoBehaviour
{

    [SerializeField] ItemDataBase itemDataBase;
    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject deleteCheck;
    [SerializeField] GameObject deleteSelect;
    [SerializeField] GameObject deleted;
    [SerializeField] private Transform clothesParent;

    private void Awake()
    {
        Init();
    }

    // 探索ボタンが押されたとき
    public void OnClickGameButton()
    {
        Init();
        SceneController.SceneChange("Move");
    }
    // キャラメイクボタンが押されたとき
    public void OnClickMakeButton()
    {
        SceneController.SceneChange("CharaMake");
    }
    // 図鑑ボタンが押されたとき
    public void OnClickZukanButton()
    {
        SceneController.SceneChange("Zukan");
    }
    // オプションボタンが押されたとき
    public void OnClickOptionButton()
    {
        // オプションを閉じるなら
        if (optionPanel.activeSelf)
        {
            deleteCheck.SetActive(false);
            deleteSelect.SetActive(true);
            deleted.SetActive(false);
        }
        optionPanel.SetActive(!optionPanel.activeSelf);
    }
    // オプション終了ボタンが押されたとき
    public void OnClickOptionCloseButton()
    {
        deleteCheck.SetActive(false);
        deleteSelect.SetActive(true);
        deleted.SetActive(false);
        optionPanel.SetActive(false);
    }
    // データ削除ボタンが押されたとき
    public void OnClickDeleteDataButton()
    {
        deleteCheck.SetActive(true);
        deleteSelect.SetActive(false);
    }
    // データ削除了承ボタンが押されたとき
    public void OnClickYesDeleteButton()
    {
        deleteCheck.SetActive(false);
        deleted.SetActive(true);
        DeleteSaveData();
    }
    // データ削除拒否ボタンが押されたとき
    public void OnClickNoDeleteButton()
    {
        deleteCheck.SetActive(false);
        deleteSelect.SetActive(true);
    }
    

    private void Init()
    {
        List<CharaItem> charaItemList = itemDataBase.GetCharaItemList();
        foreach(var item in charaItemList)
        {
            item.ResetNeedFlag();   
        }
        PlayerHP.playerHP = 5;
        HitHear.killNum = 0;
        PlayerHP.dathNum = 0;
        ItemPicker.itemScore = 0;
        SpawnEnemy.enemyNum = 0;
    }

    private void DeleteSaveData()
    {
        CharaItem.selectedName.hat = "hat_none";
        CharaItem.selectedName.body = "body_none";
        CharaItem.selectedName.bottoms = "bottoms_none";
        CharaItem.selectedName.shoes = "shoes_none";
        CharaItem.selectedName.sox = "sox_none";
        CharaItem.selectedName.tops = "tops_none";
        itemDataBase.ResetData();
        this.GetComponent<SaveManager>().OnSave();
        this.GetComponent<SaveManager>().DeleteSaveData();

        // 衣装を更新
        foreach (Transform n in clothesParent)
        {
            Destroy(n.gameObject);
        }
        CharaItem item_body = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.body);
        GameObject obj;
        obj = Instantiate(item_body.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        CharaItem item_bottoms = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.bottoms);
        obj = Instantiate(item_bottoms.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        Debug.Log("セーブデータを削除しました。");
    }
   
}
