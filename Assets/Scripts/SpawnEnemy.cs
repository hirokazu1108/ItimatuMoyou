using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static int enemyNum = 0;
    private int max_enemyNum = 40;

    static int spawnFloor = 0;
    [SerializeField] private ItemDataBase itemDataBase;
    [SerializeField] private GameObject enemyModel;

    private List<CharaItem> charaItemList;
    Vector3 spawnPos = new Vector3(0, 0, 0);  // �G�̐����ꏊ
    [SerializeField] private GameObject[] spawnerVec1; //1�K�̐����ꏊ�̌��
    [SerializeField] private GameObject[] spawnerVec2; //2�K�̐����ꏊ�̌��
    

    float sum_weight = 0.0f; //�A�C�e���o�����̑��a    !! not 0
    float[] border; // �A�C�e���o�����̋��E
    private float timeBetweenSpon = 5.0f;
    private float timer;

    void Start()
    {

        // �A�C�e���o�����̑��a�����߂�
        charaItemList = itemDataBase.GetCharaItemList();
        for (int i = 0; i < charaItemList.Count; i++)
        {
            sum_weight += charaItemList[i].GetWeight();
        }
        if (sum_weight <= 0.0f)
        {
            Debug.Log("Error: \"sum_weight\" is illegal number.");
        }

        //  �A�C�e���o�����̋��E�����߂�
        border = new float[charaItemList.Count + 1];
        border[0] = 0.0f;
        float sum_w = 0.0f;
        for (int i = 1; i < charaItemList.Count + 1; i++)
        {
            sum_w += charaItemList[i - 1].GetWeight();
            border[i] = sum_w / sum_weight;
        }

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpon)
        {
            timer = 0.0f;
            SpawnEnemyFunc();
        }
    }

    public void SpawnEnemyFunc()
    {
        spawnFloor = (spawnFloor+1)%2;
        // 1�K�ɐ���
        if(spawnFloor == 0 && enemyNum < max_enemyNum)
        {
            int rnd_spawn = (int)Random.Range(0, spawnerVec1.Length);    //�����ꏊ���i�闐��
            spawnPos = spawnerVec1[rnd_spawn].transform.position;
            enemyNum++;
        }
        // 2�K�ɐ���
        else if(spawnFloor == 1 && enemyNum < max_enemyNum)
        {
            int rnd_spawn = (int)Random.Range(0, spawnerVec2.Length);    //�����ꏊ���i�闐��
            spawnPos = spawnerVec2[rnd_spawn].transform.position;
            enemyNum++;
        }
        else
        {
            return;
        }
        
        GameObject instance = Instantiate(enemyModel, spawnPos, Quaternion.identity);  // �G�̐���
        MoveEnemy moveEnemy = instance.GetComponent<MoveEnemy>();   //���������G�̃R���|�[�l���g�̎擾
        moveEnemy.EnemyInit();  //���������G�̏�����

        float rnd_num = Random.Range(0.0f, 1.0f);    //���Ă��镞�K�`���̉񐔂��i�闐��
        float rnd_kind;  //���Ă��镞�̎�ނ��i�闐��
        int num_cloth = 0; //���Ă��镞�̐�
        CharaItem charaItem;

        // �����Ɋ�Â��Ē��Ă��镞�K�`���̉񐔂�����
        if (0.40f < rnd_num && rnd_num <= 0.95f)
        {
            num_cloth = 1;  // 1�� 45%
        }
        else if (0.95f < rnd_num && rnd_num <= 0.99f)
        {
            num_cloth = 2;  // 2�� 4%
        }
        else if (0.99f < rnd_num)
        {
            num_cloth = 3;  // 3�� 1%
        }

        // �����Ɋ�Â��ă����_���ɒ��镞��I��
        for (int i = 0; i < num_cloth; i++)
        {
            rnd_kind = Random.Range(0.0f, 1.0f);
            for (int j = 0; j < charaItemList.Count; j++)
            {
                //  �������ǂ̋��E����ɂ��邩
                if (border[j] <= rnd_kind && rnd_kind <= border[j + 1])
                {
                    charaItem = charaItemList[j];

                    // ���������G�̃X�N���v�g�ɏ�����������
                    moveEnemy.InputClothesName(charaItem.GetCategory(), charaItem.GetItemName());

                    Debug.Log($"Item:{charaItem.GetItemName()}  �m��:{(border[j + 1] - border[j]) * 100.0f}%");
                    break;
                }
            }
        }

        // ���̃I�u�W�F�N�g����
        moveEnemy.Dress();
    }

}
