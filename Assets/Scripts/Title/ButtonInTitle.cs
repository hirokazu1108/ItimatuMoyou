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

    // �T���{�^���������ꂽ�Ƃ�
    public void OnClickGameButton()
    {
        Init();
        SceneController.SceneChange("Move");
    }
    // �L�������C�N�{�^���������ꂽ�Ƃ�
    public void OnClickMakeButton()
    {
        SceneController.SceneChange("CharaMake");
    }
    // �}�Ӄ{�^���������ꂽ�Ƃ�
    public void OnClickZukanButton()
    {
        SceneController.SceneChange("Zukan");
    }
    // �I�v�V�����{�^���������ꂽ�Ƃ�
    public void OnClickOptionButton()
    {
        // �I�v�V���������Ȃ�
        if (optionPanel.activeSelf)
        {
            deleteCheck.SetActive(false);
            deleteSelect.SetActive(true);
            deleted.SetActive(false);
        }
        optionPanel.SetActive(!optionPanel.activeSelf);
    }
    // �I�v�V�����I���{�^���������ꂽ�Ƃ�
    public void OnClickOptionCloseButton()
    {
        deleteCheck.SetActive(false);
        deleteSelect.SetActive(true);
        deleted.SetActive(false);
        optionPanel.SetActive(false);
    }
    // �f�[�^�폜�{�^���������ꂽ�Ƃ�
    public void OnClickDeleteDataButton()
    {
        deleteCheck.SetActive(true);
        deleteSelect.SetActive(false);
    }
    // �f�[�^�폜�����{�^���������ꂽ�Ƃ�
    public void OnClickYesDeleteButton()
    {
        deleteCheck.SetActive(false);
        deleted.SetActive(true);
        DeleteSaveData();
    }
    // �f�[�^�폜���ۃ{�^���������ꂽ�Ƃ�
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

        // �ߑ����X�V
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

        Debug.Log("�Z�[�u�f�[�^���폜���܂����B");
    }
   
}
