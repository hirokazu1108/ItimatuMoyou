using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

// ref
// https://qiita.com/riekure/items/3fd4526b13d8e89a7fc6

public class SaveManager : MonoBehaviour
{
    private string _dataPath; // �t�@�C���p�X

    private List<CharaItem> _charaItems;
    [SerializeField] ItemDataBase itemDataBase; // �A�C�e���f�[�^�x�[�X
    

    [Serializable] private class SaveDataContainer
    {
        public SaveData[] charaItemData;
        public SelectedItem selectedItem;
    }
    [Serializable] private struct SaveData
    {
        public string itemName; 
        public bool isRegister;
    }

    private void Awake()
    {
        // �t�@�C���̃p�X���v�Z
        //dataPath = Path.Combine(Application.dataPath,"StreamingAssets/ItemData/" ,"savedata.json");
        _charaItems = itemDataBase.GetCharaItemList();


        if (PlayerPrefs.GetInt("isSave",0) == 1)
        {
            Debug.Log("����N���ł͂���܂���.");
            OnLoad();
        }
        else
        {
            OnSave();
            Debug.Log("�Z�[�u�f�[�^���쐬���܂���.");
        }

    }

    // PlayerPrefs�ŃZ�[�u
    public void OnSave()
    {
        PlayerPrefs.SetInt("isSave", 1);    //1�x�ł��Z�[�u�������Ƃ�����

        for(int i=0; i<_charaItems.Count; i++)
        {
            int flg = _charaItems[i].GetIsRegister() ? 1 : 0;
            PlayerPrefs.SetInt(_charaItems[i].GetItemName(), flg);   // �A�C�e���̓����Ԃ̕ۑ�
        }
        
        // �I�����Ă���A�C�e���̕ۑ�
        PlayerPrefs.SetString("selectedName_hat", CharaItem.selectedName.hat);
        PlayerPrefs.SetString("selectedName_body", CharaItem.selectedName.body);
        PlayerPrefs.SetString("selectedName_bottoms", CharaItem.selectedName.bottoms);
        PlayerPrefs.SetString("selectedName_tops", CharaItem.selectedName.tops);
        PlayerPrefs.SetString("selectedName_sox", CharaItem.selectedName.sox);
        PlayerPrefs.SetString("selectedName_shoes", CharaItem.selectedName.shoes);

        Debug.Log("succesed to save");
    }

    // PlayerPrefs�Ń��[�h
    public void OnLoad()
    {
        for (int i = 0; i < _charaItems.Count; i++)
        {
            _charaItems[i].SetIsRegister(PlayerPrefs.GetInt(_charaItems[i].GetItemName(), 0) == 1 ? true : false);// �A�C�e���̓����Ԃ̓ǂݍ���
        }

        // �I�����Ă���A�C�e���̓ǂݍ���
         CharaItem.selectedName.hat = PlayerPrefs.GetString("selectedName_hat", "hat_none");
         CharaItem.selectedName.body = PlayerPrefs.GetString("selectedName_body", "body_none");
         CharaItem.selectedName.bottoms = PlayerPrefs.GetString("selectedName_bottoms", "bottoms_none");
         CharaItem.selectedName.tops = PlayerPrefs.GetString("selectedName_tops", "tops_none");
         CharaItem.selectedName.sox = PlayerPrefs.GetString("selectedName_sox", "sox_none");
         CharaItem.selectedName.shoes = PlayerPrefs.GetString("selectedName_shoes", "shoes_none");

        Debug.Log("succesed to load");
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }


    // JSON�`���ɃV���A���C�Y���ăZ�[�u
    public  void OnJsonSave()
    {
        // �V���A���C�Y����I�u�W�F�N�g���쐬
        // ��2����true��JSON�����₷�����`���� 
        SaveDataContainer saveData = new SaveDataContainer();
        saveData.charaItemData = new SaveData[_charaItems.Count];

        // �Q�[���f�[�^���Z�[�u����f�[�^�Ɋi�[
        for (int i=0; i < _charaItems.Count; i++)
        {
            saveData.charaItemData[i].itemName = _charaItems[i].GetItemName();
            saveData.charaItemData[i].isRegister = _charaItems[i].GetIsRegister();
        }
        saveData.selectedItem = CharaItem.selectedName;    //�I�����Ă���ߑ��̊i�[


        // JSON�`���ɃV���A���C�Y
        var json =JsonUtility.ToJson(saveData, true);
        // JSON�f�[�^���t�@�C���ɕۑ�
        File.WriteAllText(_dataPath, json);
    }
        
    

    // JSON�`�������[�h���ăf�V���A���C�Y
    public void OnJsonLoad()
    {
        // �O�̂��߃t�@�C���̑��݃`�F�b�N
        if (!File.Exists(_dataPath)) return;
 
        // JSON�f�[�^�Ƃ��ăf�[�^��ǂݍ���
        var json = File.ReadAllText(_dataPath);

        // �ǂݍ��񂾃I�u�W�F�N�g���i�[���锠
        SaveDataContainer loadData = new SaveDataContainer();
        loadData.charaItemData = new SaveData[_charaItems.Count];

        // JSON�`������I�u�W�F�N�g�Ƀf�V���A���C�Y
        loadData = JsonUtility.FromJson<SaveDataContainer>(json);

        // �ǂݍ��񂾃f�[�^���g�p����Q�[���f�[�^�ɑ��
        for (int i = 0; i < _charaItems.Count; i++)
        {
            _charaItems[i].SetItemName(loadData.charaItemData[i].itemName);
            _charaItems[i].SetIsRegister(loadData.charaItemData[i].isRegister);
        }
        CharaItem.selectedName = loadData.selectedItem;    //�I�����Ă���ߑ��̊i�[
    }
}