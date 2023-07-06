using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukanRender : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase; //  �A�C�e���f�[�^�x�[�X
    [SerializeField] private Transform itemParent; //�ߕ��̐e
    [SerializeField] Image[] categoryButtons;

    static List<CharaItem> selectList;
    public static List<CharaItem> hasList;
    static List<CharaItem> noList;

    [SerializeField] Transform content;
    [SerializeField] GameObject itemButton;

    [SerializeField] Text num_zukanText;//�}�ӂ̊����x�e�L�X�g
    [SerializeField] Text[] num_zukanSubText;//�}�ӂ̊����x�e�L�X�g

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
        changeCategory(0);  // �����I��������
    }

    private void Update()
    {
        if (itemDataBase.GetRegisterItemNum() != itemDataBase.GetCharaItemList().Count - 6)
        {
            num_zukanText.text = itemDataBase.GetRegisterItemNum().ToString("") + "/" + (itemDataBase.GetCharaItemList().Count - 6).ToString("00");
        }
        else
        {
            num_zukanText.text = "�R���v���[�g";
        }

    }

    // �J�e�S����ύX����
    void changeCategory(int index)
    {
        selectCategory = (Category)Enum.ToObject(typeof(Category), index);  // �������ԍ�����J�e�S���̗񋓑̂����߂�
        selectList = itemDataBase.GetItemListFromCategory(selectCategory);  // �J�e�S���̗񋓑̂���Ή������A�C�e�����X�g�����߂�
        selectList.RemoveAll(x => x.GetItemName() == "hat_none" || x.GetItemName() == "body_none" || x.GetItemName() == "bottoms_none" || x.GetItemName() == "sox_none" || x.GetItemName() == "shoes_none" || x.GetItemName() == "tops_none"); //none���폜
        hasList = selectList.FindAll(x => x.GetIsRegister() == true);  // �����Ă���A�C�e�����X�g
        noList = selectList.FindAll(x => x.GetIsRegister() == false); // �����Ă��Ȃ��A�C�e�����X�g
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
            // �����Ă���A�C�e���̕\��
            if (i < hasList.Count)
            {
                btnImg.sprite = hasList[i].GetSprite();
                btnImg.color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
                btnBtn.interactable = true;
            }
            // �����Ă��Ȃ��A�C�e���̕\��
            else if (i < selectList.Count)
            {
                btnImg.sprite = noList[i - hasList.Count].GetSprite();
                btnImg.color = new Color(130 / 255.0f, 130 / 255.0f, 130 / 255.0f);
                btnBtn.interactable = false;
            }
            // �A�C�e���̕\���O
            else
            {
                btnImg.sprite = buttonImage;
                btnImg.color = new Color(130 / 255.0f, 130 / 255.0f, 130 / 255.0f);
                btnBtn.interactable = false;
            }
        }
        // �{�^���̈Â��ύX
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

    

    // �J�e�S���̃{�^�����N���b�N�����Ƃ�
    public void OnClickCategoryButton()
    {
        changeCategory(buttonIndex);
    }

    
}
