using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaMakeUI : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase; //  アイテムデータベース
    [SerializeField] private Transform clothesParent; //衣服の親
    [SerializeField] Image[] categoryButtons;
    [SerializeField] GameObject itemButton;
    static List<CharaItem> selectList;
    public static List<CharaItem> hasList;

    [SerializeField] Transform content;

    [SerializeField] int buttonIndex;
    public static Category selectCategory = Category.Hat;

    [SerializeField] Sprite buttonImage;

    void Awake()
    {
        // アイテム選択のボタン
        changeCategory(0);  // 初期選択をする
    }

    // カテゴリを変更する
    void changeCategory(int index)
    {
        
        selectCategory = (Category)Enum.ToObject(typeof(Category), index);  // 押した番号からカテゴリの列挙体を求める
        selectList = itemDataBase.GetItemListFromCategory(selectCategory);  // カテゴリの列挙体から対応したアイテムリストを求める
        hasList = selectList.FindAll(x => x.GetIsRegister() == true);  // 持っているアイテムリスト
        GameObject[] itemButtons = new GameObject[hasList.Count];
        foreach (Transform n in content)
        {
            Destroy(n.gameObject);
        }
        
        // ボタンの表示
        for (int i = 0; i < hasList.Count ; i++)
        {
            itemButtons[i] = Instantiate(itemButton, content);
            OnClickItemButton onClickItemButton = itemButtons[i].GetComponent<OnClickItemButton>();
            onClickItemButton.clothesParent = clothesParent;
            onClickItemButton.buttonIndex = i;
            itemButtons[i].GetComponent<Button>().onClick.AddListener(() => onClickItemButton.OnClickItemButtons());
            Image btnImg = itemButtons[i].GetComponent<Image>();
            Button btnBtn = itemButtons[i].GetComponent<Button>();
            // 持っているアイテムの表示
            if (i < hasList.Count)
            {
                btnImg.sprite = hasList[i].GetSprite();
                btnImg.color = new Color(255/255.0f, 255 / 255.0f, 255 / 255.0f);
                btnBtn.interactable = true;
            }
            
        }

        // ボタンの暗さ変更
        for (int i = 0; i < categoryButtons.Length; i++)
        {
            if (i != index)
            {
                categoryButtons[i].color = new Color(150f / 255f, 150f / 255f, 150f / 255f);
            }
            else
            {
                categoryButtons[i].color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            }

        }
    }

    
    // カテゴリのボタンをクリックしたとき
    public void OnClickCategoryButton()
    {
        changeCategory(buttonIndex);
    }

    
}