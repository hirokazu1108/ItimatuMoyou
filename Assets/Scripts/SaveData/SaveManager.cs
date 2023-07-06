using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

// ref
// https://qiita.com/riekure/items/3fd4526b13d8e89a7fc6

public class SaveManager : MonoBehaviour
{
    private string dataPath; // ファイルパス

    [SerializeField] private ItemDataBase itemDataBase; // アイテムデータベース
    List<CharaItem> charaItems;

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
        // ファイルのパスを計算
        //dataPath = Path.Combine(Application.dataPath,"StreamingAssets/ItemData/" ,"savedata.json");
        charaItems = itemDataBase.GetCharaItemList();


        if (PlayerPrefs.GetInt("isSave",0) == 1)
        {
            Debug.Log("初回起動ではありません.");
            OnLoad();
        }
        else
        {
            OnSave();
            Debug.Log("セーブデータを作成しました.");
        }

    }
    private void Start()
    {
        
    }

    // PlayerPrefsでセーブ
    public void OnSave()
    {
        PlayerPrefs.SetInt("isSave", 1);    //1度でもセーブしたことを示す

        for(int i=0; i<charaItems.Count; i++)
        {
            int flg = charaItems[i].GetIsRegister() ? 1 : 0;
            PlayerPrefs.SetInt(charaItems[i].GetItemName(), flg);   // アイテムの入手状態の保存
        }
        
        // 選択しているアイテムの保存
        PlayerPrefs.SetString("selectedName_hat", CharaItem.selectedName.hat);
        PlayerPrefs.SetString("selectedName_body", CharaItem.selectedName.body);
        PlayerPrefs.SetString("selectedName_bottoms", CharaItem.selectedName.bottoms);
        PlayerPrefs.SetString("selectedName_tops", CharaItem.selectedName.tops);
        PlayerPrefs.SetString("selectedName_sox", CharaItem.selectedName.sox);
        PlayerPrefs.SetString("selectedName_shoes", CharaItem.selectedName.shoes);

        Debug.Log("succesed to save");
    }

    // PlayerPrefsでロード
    public void OnLoad()
    {
        for (int i = 0; i < charaItems.Count; i++)
        {
            charaItems[i].SetIsRegister(PlayerPrefs.GetInt(charaItems[i].GetItemName(), 0) == 1 ? true : false);// アイテムの入手状態の読み込み
        }

        // 選択しているアイテムの読み込み
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


    // JSON形式にシリアライズしてセーブ
    public  void OnJsonSave()
    {
        // シリアライズするオブジェクトを作成
        // 第2引数trueでJSONを見やすく整形する 
        SaveDataContainer saveData = new SaveDataContainer();
        saveData.charaItemData = new SaveData[charaItems.Count];

        // ゲームデータをセーブするデータに格納
        for (int i=0; i < charaItems.Count; i++)
        {
            saveData.charaItemData[i].itemName = charaItems[i].GetItemName();
            saveData.charaItemData[i].isRegister = charaItems[i].GetIsRegister();
        }
        saveData.selectedItem = CharaItem.selectedName;    //選択している衣装の格納


        // JSON形式にシリアライズ
        var json =JsonUtility.ToJson(saveData, true);
        // JSONデータをファイルに保存
        File.WriteAllText(dataPath, json);
    }
        
    

    // JSON形式をロードしてデシリアライズ
    public void OnJsonLoad()
    {
        // 念のためファイルの存在チェック
        if (!File.Exists(dataPath)) return;
 
        // JSONデータとしてデータを読み込む
        var json = File.ReadAllText(dataPath);

        // 読み込んだオブジェクトを格納する箱
        SaveDataContainer loadData = new SaveDataContainer();
        loadData.charaItemData = new SaveData[charaItems.Count];

        // JSON形式からオブジェクトにデシリアライズ
        loadData = JsonUtility.FromJson<SaveDataContainer>(json);

        // 読み込んだデータを使用するゲームデータに代入
        for (int i = 0; i < charaItems.Count; i++)
        {
            charaItems[i].SetItemName(loadData.charaItemData[i].itemName);
            charaItems[i].SetIsRegister(loadData.charaItemData[i].isRegister);
        }
        CharaItem.selectedName = loadData.selectedItem;    //選択している衣装の格納
    }
}