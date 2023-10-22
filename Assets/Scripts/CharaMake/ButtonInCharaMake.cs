using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInCharaMake : MonoBehaviour
{
    private Camera mainCam; //�J����
    [SerializeField] private GameObject model;  // ���f��
    private void Start()
    {
        mainCam = Camera.main; 
    }
    // �^�C�g���{�^���������ꂽ�Ƃ�
    public void OnClickTitleButton()
    {
        Title.isUpdate = true; // �^�C�g���̃L�������C�N�I�u�W�F�N�g�̍X�V�t���O
        SceneController.SceneChange("Title");
    }
    // ���Z�b�g�{�^���������ꂽ�Ƃ�
    public void OnClickResetButton()
    {
        mainCam.fieldOfView = ViewControl.maxFieldOfView;   //�g�嗦�̃��Z�b�g
        
        model.transform.rotation = Quaternion.Euler(0, ViewControl.baseRotateY, 0); //��]�̃��Z�b�g
        ViewControl.rotateY = ViewControl.baseRotateY;
        model.transform.position = new Vector3(ViewControl.basePosX, ViewControl.basePosY, -7); //�ړ��̃��Z�b�g
        ViewControl.posX = ViewControl.basePosX;
        ViewControl.posY = ViewControl.basePosY;

    }
}
