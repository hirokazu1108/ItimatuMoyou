using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public static bool isUpdate = true; // 衣装更新がいるかのフラグ
    [SerializeField] private Transform clothesParent;
    [SerializeField] private ItemDataBase itemDataBase;
    private SaveManager saveManagerCs;

    [SerializeField] private AudioSource audioSource;//AudioSource型の変数aを宣言
    [SerializeField] private GameObject optionPanel;

    private void Start()
    {
        saveManagerCs = gameObject.GetComponent<SaveManager>(); //セーブ用
        saveManagerCs.OnLoad(); //データ読み込み
    }



    void Update()
    {
        // 衣装の更新とデータ読み込み
        if (isUpdate)
        {
            optionPanel.SetActive(false);
            audioSource.Play();
            saveManagerCs.OnLoad();
            Dress();
            isUpdate = false;
        }
        audioSource.volume = Option.bgmVolume;  //bgmの大きさを設定

    }

    // 服を着せる関数
    private void Dress()
    {
        foreach(Transform n in clothesParent)
        {
            Destroy(n.gameObject);
        }
        GameObject obj;
        if (CharaItem.selectedName.hat != "hat_none")
        {
            CharaItem item_hat = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.hat);
            obj = Instantiate(item_hat.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (CharaItem.selectedName.body != "body_none")
        {
            CharaItem item_body = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.body);
            obj = Instantiate(item_body.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        else if(CharaItem.selectedName.tops == "tops_none")
        {
            CharaItem item_body = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.body);
            obj = Instantiate(item_body.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (CharaItem.selectedName.bottoms != "bottoms_none")
        {
            CharaItem item_bottoms = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.bottoms);
            obj = Instantiate(item_bottoms.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }else if (CharaItem.selectedName.tops == "tops_none")
        {
            CharaItem item_bottoms = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.bottoms);
            obj = Instantiate(item_bottoms.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (CharaItem.selectedName.sox != "sox_none")
        {
            CharaItem item_sox = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.sox);
            obj = Instantiate(item_sox.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (CharaItem.selectedName.shoes != "shoes_none")
        {
            CharaItem item_shoes = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.shoes);
            obj = Instantiate(item_shoes.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (CharaItem.selectedName.tops != "tops_none")
        {
            CharaItem item_tops = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.tops);
            obj = Instantiate(item_tops.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
    }
}
