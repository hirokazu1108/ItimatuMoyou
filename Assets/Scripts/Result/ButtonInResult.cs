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

    // �擾�A�C�e���̊m�F�{�^���������ꂽ�Ƃ�
    public void OnClickCehekButton()
    {
        CreateCell();
        scrollView.SetActive(true);
    }

    // �A�C�e���ꗗ�̃o�c�������ꂽ�Ƃ�
    public void OnClickCloseButton()
    {
        DeleteCell();
        scrollView.SetActive(false);
    }



    // �Z���̃I�u�W�F�N�g�����
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

    // �Z���̃I�u�W�F�N�g���폜����
    private void DeleteCell()
    {
        foreach (Transform n in component)
        {
            GameObject.Destroy(n.gameObject);
        }
    }

    // �L�������C�N�{�^���������ꂽ�Ƃ�
    public void OnClickCharaMakeButton()
    {
        SceneController.SceneChange("CharaMake");
    }

}
