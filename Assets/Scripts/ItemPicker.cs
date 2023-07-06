using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ForceItems
{
    public int power;
    public int speed;
    public int heal;
}

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;
    public static ForceItems num_forceItem;  //�����A�C�e���̓��萔
    public static float itemScore = 0;
    public static float speedflg = 0;
    private float timeBetweenWalk = 5.0f;
    private float timer;
    void Start()
    {
        /* ������ */
        num_forceItem.power = 0;
        num_forceItem.speed = 0;
        num_forceItem.heal = 0;
    }

    void Update()
    {
        if (speedflg == 1)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenWalk)
            {
                speedflg = 0;
                timer = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerItem"))
        {
            num_forceItem.power += 1;
            Destroy(other.gameObject);
            Debug.Log($"�U���̓A�b�v.���݂̌�:{num_forceItem.power}��");
        }
        else if (other.CompareTag("speedItem"))
        {
            speedflg = 1;
            num_forceItem.speed += 1;
            Destroy(other.gameObject);
            Debug.Log($"�X�s�[�h�A�b�v.���݂̌�:{num_forceItem.speed}��");
        }
        else if (other.CompareTag("healItem"))
        {
            PlayerHP.playerHP += 1;
            num_forceItem.heal += 1;
            Destroy(other.gameObject);
            Debug.Log($"��.���݂̌�:{num_forceItem.heal}��");
        }else if (other.CompareTag("charaItem"))
        {
            CharaItem charaItem = itemDataBase.GetCharaItemFromName(other.name);
            charaItem.SetHasItem(true);
            charaItem.SetIsRegister(true);
            Destroy(other.gameObject);
            Debug.Log($"�A�C�e��\"{other.name}\"���擾");
            itemScore += charaItem.GetScore();
        }
    }
}
