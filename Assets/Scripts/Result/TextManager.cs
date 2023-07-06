using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] ItemDataBase itemDataBase;
    [SerializeField] Text enemyText;    //�|�����G���̃e�L�X�g
    [SerializeField] Text itemText;     //�W�߂��A�C�e���̎�ސ��̃e�L�X�g
    [SerializeField] Text scoreText;    //�X�R�A�̃e�L�X�g
    private float scoreAll;
    void Start()
    {
        
    }

    void Update()
    {
        itemText.text = itemDataBase.GetHasItemNum().ToString("00") + " 種類";
        enemyText.text = HitHear.killNum.ToString("00");
        scoreAll = ItemPicker.itemScore + HitHear.killNum * 100 - PlayerHP.dathNum * 500 + itemDataBase.GetHasItemNum() * 500;
        scoreText.text = scoreAll.ToString("00");
    }
}
