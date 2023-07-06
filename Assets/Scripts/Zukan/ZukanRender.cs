using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukanRender : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase; //  アイテムデータベース
    [SerializeField] private Transform itemParent; //衣服の親
    [SerializeField] Image[] categoryButtons;

    static List<CharaItem> selectList;
    public static List<CharaItem> hasList;
    static List<CharaItem> noList;

    [SerializeField] Transform content;
    [SerializeField] GameObject itemButton;

    [SerializeField] Text num_zukanText;//図鑑の完成度テキスト
    [SerializeField] Text[] num_zukanSubText;//図鑑の完成度テキスト

    [SerializeField] int buttonIndex;
    public static Category selectCategory = Category.Hat;


    [SerializeField] Sprite buttonImage;
    void Start()
    {
        num_zukanSubText[0].text = itemDataBase.GetRegisterCategoryItemNum(Category.Hat).ToString("00") + " / " + itemDataBase.GetCategoryItemNum(Category.Hat).ToString("00");
        num_zukanSubText[1].text = itemDataBase.GetRegisterCategoryItemNum(Category.Body).ToString("00") + " / " + itemDataBase.GetCategoryItemNum(Category.Body).ToString("00");
        num_zukanSubText[2].text = itemDataBase.GetRegisterCategoryItemNum(Category.Bottoms).ToString("00") + " / " + itemDataBase.GetCategoryItemNum(Category.Bottoms).ToString("00");
        num_zukanSubText[3].text = itemDataBase.GetRegisterCategoryItemNum(Category.Tops).ToString("00") + " / " + itemDataBase.GetCategoryItemNum(Category.Tops).ToString("00");
        num_zukanSubText[4].text = itemDataBase.GetRegisterCategoryItemNum(Category.Sox).ToString("00") + " / " + itemDataBase.GetCategoryItemNum(Category.Sox).ToString("00");
        num_zukanSubText[5].text = itemDataBase.GetRegisterCategoryItemNum(Category.Shoes).ToString("00") + " / " + itemDataBase.GetCategoryItemNum(Category.Shoes).ToString("00");
        changeCategory(0);  // 初期選択をする
    }

    private void Update()
    {
        if (itemDataBase.GetRegisterItemNum() != itemDataBase.GetCharaItemList().Count - 6)
        {
            num_zukanText.text = itemDataBase.GetRegisterItemNum().ToString("") + "/" + (itemDataBase.GetCharaItemList().Count - 6).ToString("00");
        }
        else
        {
            num_zukanText.text = "コンプリート";
        }

    }

    // カテゴリを変更する
    void changeCategory(int index)
    {
        selectCategory = (Category)Enum.ToObject(typeof(Category), index);  // 押した番号からカテゴリの列挙体を求める
        selectList = itemDataBase.GetItemListFromCategory(selectCategory);  // カテゴリの列挙体から対応したアイテムリストを求める
        selectList.RemoveAll(x => x.GetItemName() == "hat_none" || x.GetItemName() == "body_none" || x.GetItemName() == "bottoms_none" || x.GetItemName() == "sox_none" || x.GetItemName() == "shoes_none" || x.GetItemName() == "tops_none"); //noneを削除
        hasList = selectList.FindAll(x => x.GetIsRegister() == true);  // 持っているアイテムリスト
        noList = selectList.FindAll(x => x.GetIsRegister() == false); // 持っていないアイテムリスト
        GameObject[] itemButtons = new GameObject[selectList.Count];
        foreach (Transform n in content)
        {
            Destroy(n.gameObject);
        }

        for (int i = 0; i < selectList.Count; i++)
        {
            itemButtons[i] = Instantiate(itemButton, content);
            ZukanItemButton zukanItemButton = itemButtons[i].GetComponent<ZukanItemButton>();
            zukanItemButton.itemParent = itemParent;
            zukanItemButton.buttonIndex = i;
            itemButtons[i].GetComponent<Button>().onClick.AddListener(() => zukanItemButton.OnClickItemButton());
            Image btnImg = itemButtons[i].GetComponent<Image>();
            Button btnBtn = itemButtons[i].GetComponent<Button>();
            // 持っているアイテムの表示
            if (i < hasList.Count)
            {
                btnImg.sprite = hasList[i].GetSprite();
                btnImg.color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
                btnBtn.interactable = true;
            }
            // 持っていないアイテムの表示
            else if (i < selectList.Count)
            {
                btnImg.sprite = noList[i - hasList.Count].GetSprite();
                btnImg.color = new Color(130 / 255.0f, 130 / 255.0f, 130 / 255.0f);
                btnBtn.interactable = false;
            }
            // アイテムの表示外
            else
            {
                btnImg.sprite = buttonImage;
                btnImg.color = new Color(130 / 255.0f, 130 / 255.0f, 130 / 255.0f);
                btnBtn.interactable = false;
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
