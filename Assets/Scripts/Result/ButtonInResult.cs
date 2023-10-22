using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInResult : MonoBehaviour
{
    [SerializeField] GameObject scrollView;

    [SerializeField] ItemDataBase itemDataBase;
    [SerializeField] GameObject cell;
    [SerializeField] Transform component;

    // 取得アイテムの確認ボタンが押されたとき
    public void OnClickCehekButton()
    {
        CreateCell();
        scrollView.SetActive(true);
    }

    // アイテム一覧のバツが押されたとき
    public void OnClickCloseButton()
    {
        DeleteCell();
        scrollView.SetActive(false);
    }



    // セルのオブジェクトを作る
    private void CreateCell()
    {
        List<CharaItem> hasItemList = itemDataBase.GetHasCharaItemList();

        foreach (var item in hasItemList)
        {
            if(item.name != "hat_none" && item.name != "body_none" && item.name != "bottoms_none" && item.name != "shoes_none" && item.name != "sox_none" && item.name != "tops_none")
            {
                GameObject instance = Instantiate(cell, component);
                instance.GetComponent<Image>().sprite = item.GetSprite();
            }
        }
    }

    // セルのオブジェクトを削除する
    private void DeleteCell()
    {
        foreach (Transform n in component)
        {
            GameObject.Destroy(n.gameObject);
        }
    }

    // キャラメイクボタンが押されたとき
    public void OnClickCharaMakeButton()
    {
        SceneController.SceneChange("CharaMake");
    }

}
