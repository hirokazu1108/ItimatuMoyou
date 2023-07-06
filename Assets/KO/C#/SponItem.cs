using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponItem : MonoBehaviour
{
    static int spawnFloor = 0;
    [SerializeField] private GameObject itemspeed;
    [SerializeField] private GameObject itemHP;
    Vector3 spawnPos = new Vector3(0, 0, 0);  // �G�̐����ꏊ
    [SerializeField] private GameObject[] spawnerVec1; //1�K�̐����ꏊ�̌��
    [SerializeField] private GameObject[] spawnerVec2; //2�K�̐����ꏊ�̌��

    float[] border; // �A�C�e���o�����̋��E
    private float timeBetweenSpon = 10.0f;
    private float timer;

    void Start()
    {

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
        if(spawnFloor == 0)
        {
            int rnd_spawn = (int)Random.Range(0, spawnerVec1.Length);    //�����ꏊ���i�闐��
            spawnPos = spawnerVec1[rnd_spawn].transform.position;
        }
        // 2�K�ɐ���
        else
        {
            int rnd_spawn = (int)Random.Range(0, spawnerVec2.Length);    //�����ꏊ���i�闐��
            spawnPos = spawnerVec2[rnd_spawn].transform.position;
        }

        int rnd_num = Random.Range(0, 2);

        if (rnd_num == 0)
        {
            GameObject instance = Instantiate(itemHP, spawnPos, Quaternion.identity);
        }
        if (rnd_num == 1)
        {
            GameObject instance = Instantiate(itemspeed, spawnPos, Quaternion.identity);
        }
    }
}