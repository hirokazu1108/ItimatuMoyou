using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaMakeUI : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase; //  �A�C�e���f�[�^�x�[�X
    [SerializeField] private Transform clothesParent; //�ߕ��̐e
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
        // �A�C�e���I���̃{�^��
        changeCategory(0);  // �����I��������
    }

    // �J�e�S����ύX����
    void changeCategory(int index)
    {
        
        selectCategory = (Category)Enum.ToObject(typeof(Category), index);  // �������ԍ�����J�e�S���̗񋓑̂����߂�
        selectList = itemDataBase.GetItemListFromCategory(selectCategory);  // �J�e�S���̗񋓑̂���Ή������A�C�e�����X�g�����߂�
        hasList = selectList.FindAll(x => x.GetIsRegister() == true);  // �����Ă���A�C�e�����X�g
        GameObject[] itemButtons = new GameObject[hasList.Count];
        foreach (Transform n in content)
        {
            Destroy(n.gameObject);
        }
        
        // �{�^���̕\��
        for (int i = 0; i < hasList.Count ; i++)
        {
            itemButtons[i] = Instantiate(itemButton, content);
            OnClickItemButton onClickItemButton = itemButtons[i].GetComponent<OnClickItemButton>();
            onClickItemButton.clothesParent = clothesParent;
            onClickItemButton.buttonIndex = i;
            itemButtons[i].GetComponent<Button>().onClick.AddListener(() => onClickItemButton.OnClickItemButtons());
            Image btnImg = itemButtons[i].GetComponent<Image>();
            Button btnBtn = itemButtons[i].GetComponent<Button>();
            // �����Ă���A�C�e���̕\��
            if (i < hasList.Count)
            {
                btnImg.sprite = hasList[i].GetSprite();
                btnImg.color = new Color(255/255.0f, 255 / 255.0f, 255 / 255.0f);
                btnBtn.interactable = true;
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