using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInZukan : MonoBehaviour
{
    [SerializeField] private Transform itemParent; //�ߕ��̐e
    // �^�C�g���{�^���������ꂽ�Ƃ�
    public void OnClickTitleButton()
    {
        Title.isUpdate = true; // �^�C�g���̃L�������C�N�I�u�W�F�N�g�̍X�V�t���O
        SceneController.SceneChange("Title");
    }
    // ���Z�b�g�{�^���������ꂽ�Ƃ�
    public void OnClickResetButton()
    {
        itemParent.rotation = Quaternion.Euler(0, ZukanViewController.baseRotateY, 0);
        ZukanViewController.rotateY = ZukanViewController.baseRotateY;
    }
}
