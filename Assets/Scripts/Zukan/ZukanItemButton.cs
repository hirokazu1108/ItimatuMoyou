using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZukanItemButton : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase; //  �A�C�e���f�[�^�x�[�X
    public Transform itemParent; //�ߕ��̐e
    public int buttonIndex;

    // �A�C�e���̃I�u�W�F�N�g�𐶐�����֐�
    private void CreateClothObject(Category cat, string name)
    {
        foreach (Transform n in itemParent)
        {
            Destroy(n.gameObject);
        }
        GameObject instance = Instantiate(itemDataBase.GetCharaItemFromName(name).GetGameObject(), itemParent);

        // �I�t�Z�b�g�ł���ق����悳��
        switch (cat)
        {
            case Category.Hat:
                if (name == "hat_sister")
                {
                    instance.transform.localPosition = new Vector3(0, -0.2f, 0);
                    instance.transform.localRotation = Quaternion.Euler(8, 0, 0);
                    instance.transform.localScale *= 1.2f;
                }
                else
                {
                    instance.transform.localPosition = new Vector3(0, -1.5f, 0);
                    instance.transform.localRotation = Quaternion.Euler(8, 0, 0);
                    instance.transform.localScale *= 1.3f;
                }
                break;
            case Category.Body:
                instance.transform.localPosition = new Vector3(0, -0.5f, 0);
                instance.transform.localRotation = Quaternion.Euler(0, 10, 0);
                instance.transform.localScale *= 2.1f;
                break;
            case Category.Bottoms:
                instance.transform.localPosition = new Vector3(0, -1.5f, 0);
                instance.transform.localRotation = Quaternion.Euler(0, 0, 0);
                instance.transform.localScale *= 3f;
                break;
            case Category.Tops:
                instance.transform.localPosition = new Vector3(0, 1.0f, 0);
                instance.transform.localRotation = Quaternion.Euler(0, 0, 0);
                instance.transform.localScale *= 1.6f;
                break;
            case Category.Sox:
                if (name == "sox_simple")
                {
                    instance.transform.localPosition = new Vector3(0, 2f, 0);
                    instance.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    instance.transform.localScale *= 3.5f;
                }
                else
                {
                    instance.transform.localPosition = new Vector3(0, 1.2f, 0);
                    instance.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    instance.transform.localScale *= 2.2f;
                }

                break;
            case Category.Shoes:
                instance.transform.localPosition = new Vector3(0, 2.3f, 0);
                instance.transform.localRotation = Quaternion.Euler(0, 0, 0);
                instance.transform.localScale *= 3.5f;
                break;
        }

    }

    // �A�C�e���̃{�^�����N���b�N�����Ƃ�
    public void OnClickItemButton()
    {
        int pushedButton = buttonIndex;
        itemParent.rotation = Quaternion.Euler(0, ZukanViewController.baseRotateY, 0);
        CreateClothObject(ZukanRender.selectCategory, ZukanRender.hasList[pushedButton].GetItemName());
    }

}
