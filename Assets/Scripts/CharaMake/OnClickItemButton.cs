using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickItemButton : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase; //  アイテムデータベース
    public Transform clothesParent; //衣服の親
    [SerializeField] GameObject Obj_none;
    [SerializeField] public int buttonIndex;

    private void Start()
    {

        DressUp();  // セーブデータの衣装に着替える
    }
    // 着せ替え画面の全衣装の着せ替えを行う
    public void DressUp()
    {
        foreach (Transform t in clothesParent)
        {
            Destroy(t.gameObject);
        }

        CharaItem item_hat = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.hat);
        CharaItem item_body = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.body);
        CharaItem item_bottoms = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.bottoms);
        CharaItem item_sox = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.sox);
        CharaItem item_shoes = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.shoes);
        CharaItem item_tops = itemDataBase.GetCharaItemFromName(CharaItem.selectedName.tops);

        GameObject[] obj = new GameObject[6];
        obj[0] = Instantiate(item_hat.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        if (CharaItem.selectedName.tops != "tops_none")
        {
            obj[1] = Instantiate(Obj_none, Vector3.zero, Quaternion.identity, clothesParent);
        }
        else
        {
            obj[1] = Instantiate(item_body.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        }
        // topsに何か着ている　or　タイツをはいている
        if ((CharaItem.selectedName.tops != "tops_none") || (CharaItem.selectedName.sox == "sox_black_santa" || CharaItem.selectedName.sox == "sox_blue_santa" || CharaItem.selectedName.sox == "sox_brown_santa" || CharaItem.selectedName.sox == "sox_green_santa" || CharaItem.selectedName.sox == "sox_navy_santa" || CharaItem.selectedName.sox == "sox_sister" || CharaItem.selectedName.sox == "sox_yellow_santa" || CharaItem.selectedName.sox == "sox_sister_blue" || CharaItem.selectedName.sox == "sox_sister_brown" || CharaItem.selectedName.sox == "sox_sister_green"))
        {
            obj[2] = Instantiate(Obj_none, Vector3.zero, Quaternion.identity, clothesParent);
        }
        else
        {
            obj[2] = Instantiate(item_bottoms.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        }
        obj[3] = Instantiate(item_sox.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        obj[4] = Instantiate(item_shoes.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
        obj[5] = Instantiate(item_tops.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);

        for (int i = 0; i < 6; i++)
        {
            obj[i].transform.localPosition = Vector3.zero;
            obj[i].transform.localRotation = Quaternion.identity;
        }

    }

    // アイテムのボタンをクリックしたとき
    public void OnClickItemButtons()
    {

        int pushedButton = buttonIndex;
        // オフセットでするほうがよさげ
        switch (CharaMakeUI.selectCategory)
        {
            case Category.Hat:
                CharaItem.selectedName.hat = String.Copy(CharaMakeUI.hasList[pushedButton].GetItemName());
                break;
            case Category.Body:
                CharaItem.selectedName.body = String.Copy(CharaMakeUI.hasList[pushedButton].GetItemName());
                CharaItem.selectedName.tops = "tops_none";
                break;
            case Category.Bottoms:
                CharaItem.selectedName.bottoms = String.Copy(CharaMakeUI.hasList[pushedButton].GetItemName());
                CharaItem.selectedName.tops = "tops_none";
                // タイツをはいているなら
                if (CharaItem.selectedName.sox == "sox_black_santa" || CharaItem.selectedName.sox == "sox_blue_santa" || CharaItem.selectedName.sox == "sox_brown_santa" || CharaItem.selectedName.sox == "sox_green_santa" || CharaItem.selectedName.sox == "sox_navy_santa" || CharaItem.selectedName.sox == "sox_sister" || CharaItem.selectedName.sox == "sox_yellow_santa" || CharaItem.selectedName.sox == "sox_sister_blue" || CharaItem.selectedName.sox == "sox_sister_brown" || CharaItem.selectedName.sox == "sox_sister_green")
                {
                    CharaItem.selectedName.sox = "sox_none";
                }
                break;
            case Category.Tops:
                CharaItem.selectedName.tops = String.Copy(CharaMakeUI.hasList[pushedButton].GetItemName());
                CharaItem.selectedName.body = "body_none";
                CharaItem.selectedName.bottoms = "bottoms_none";
                break;
            case Category.Sox:
                CharaItem.selectedName.sox = String.Copy(CharaMakeUI.hasList[pushedButton].GetItemName());
                break;
            case Category.Shoes:
                CharaItem.selectedName.shoes = String.Copy(CharaMakeUI.hasList[pushedButton].GetItemName());
                break;
        }
        this.GetComponent<SaveManager>().OnSave();
        DressUp();
    }
}
