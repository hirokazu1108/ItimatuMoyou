using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;

    public string clothes_hat;
    public string clothes_body;
    public string clothes_bottoms;
    public string clothes_shoes;
    public string clothes_sox;
    public string clothes_tops;
    [SerializeField] private ItemDataBase itemDataBase; //  アイテムデータベース
    [SerializeField] private Transform dropParent; //衣服の親

    void Start()
    {

    }

    void Update()
    {
        // ターゲットの位置を目的地に設定する。
        agent.destination = target.transform.position;
    }

    public void EnemyInit()
    {
        clothes_hat = "hat_none";
        clothes_body = "body_none";
        clothes_bottoms = "bottoms_none";
        clothes_shoes = "shoes_none";
        clothes_sox = "sox_none";
        clothes_tops = "tops_none";

        target = GameObject.Find("Target_nav");
        agent = GetComponent<NavMeshAgent>();

        dropParent = GameObject.Find("dropParent").transform;
    }
    public void InputClothesName(Category cat, string name)
    {
        // 生成した敵のスクリプトに情報を書き込む
        switch (cat)
        {
            case Category.Hat:
                clothes_hat = string.Copy(name);
                break;
            case Category.Body:
                clothes_body = string.Copy(name);
                break;
            case Category.Bottoms:
                clothes_bottoms = string.Copy(name);
                break;
            case Category.Tops:
                clothes_tops = string.Copy(name);
                break;
            case Category.Sox:
                clothes_sox = string.Copy(name);
                break;
            case Category.Shoes:
                clothes_shoes = string.Copy(name);
                break;
        }
    }

    // 服を着せる関数
    public void Dress()
    {
        GameObject obj;
        Transform clothesParent = this.transform.Find("clothesParent").transform;

        if (clothes_hat != "hat_none")
        {
            CharaItem item_hat = itemDataBase.GetCharaItemFromName(clothes_hat);
            obj = Instantiate(item_hat.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

        }
        if (clothes_body != "body_none")
        {
            CharaItem item_body = itemDataBase.GetCharaItemFromName(clothes_body);
            obj = Instantiate(item_body.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (clothes_bottoms != "bottoms_none")
        {
            CharaItem item_bottoms = itemDataBase.GetCharaItemFromName(clothes_bottoms);
            obj = Instantiate(item_bottoms.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (clothes_sox != "sox_none")
        {
            CharaItem item_sox = itemDataBase.GetCharaItemFromName(clothes_sox);
            obj = Instantiate(item_sox.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (clothes_shoes != "shoes_none")
        {
            CharaItem item_shoes = itemDataBase.GetCharaItemFromName(clothes_shoes);
            obj = Instantiate(item_shoes.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
        if (clothes_tops != "tops_none")
        {
            CharaItem item_tops = itemDataBase.GetCharaItemFromName(clothes_tops);
            obj = Instantiate(item_tops.GetGameObject(), Vector3.zero, Quaternion.identity, clothesParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
    }

    // アイテムのドロップ処理を行う
    void DropItem()
    {
        GameObject obj;

        if (clothes_hat != "hat_none")
        {
            CharaItem item_hat = itemDataBase.GetCharaItemFromName(clothes_hat);
            obj = Instantiate(item_hat.GetGameObject(), this.transform.position, this.transform.rotation, dropParent);
            obj.transform.localScale *= 0.3f;
            obj.name = clothes_hat;

        }
        if (clothes_body != "body_none")
        {
            CharaItem item_body = itemDataBase.GetCharaItemFromName(clothes_body);
            obj = Instantiate(item_body.GetGameObject(), this.transform.position, this.transform.rotation, dropParent);
            obj.transform.localScale *= 0.3f;
            obj.name = clothes_body;
        }
        if (clothes_bottoms != "bottoms_none")
        {
            CharaItem item_bottoms = itemDataBase.GetCharaItemFromName(clothes_bottoms);
            obj = Instantiate(item_bottoms.GetGameObject(), this.transform.position, this.transform.rotation, dropParent);
            obj.transform.localScale *= 0.45f;
            obj.name = clothes_bottoms;
        }
        if (clothes_sox != "sox_none")
        {
            CharaItem item_sox = itemDataBase.GetCharaItemFromName(clothes_sox);
            obj = Instantiate(item_sox.GetGameObject(), this.transform.position, this.transform.rotation, dropParent);
            obj.transform.localScale *= 0.6f;
            obj.name = clothes_sox;
        }
        if (clothes_shoes != "shoes_none")
        {
            CharaItem item_shoes = itemDataBase.GetCharaItemFromName(clothes_shoes);
            obj = Instantiate(item_shoes.GetGameObject(), this.transform.position, this.transform.rotation, dropParent);
            obj.transform.localScale *= 0.6f;
            obj.name = clothes_shoes;
        }
        if (clothes_tops != "tops_none")
        {
            CharaItem item_tops = itemDataBase.GetCharaItemFromName(clothes_tops);
            obj = Instantiate(item_tops.GetGameObject(), this.transform.position, this.transform.rotation, dropParent);
            obj.transform.localScale *= 0.30f;
            obj.name = clothes_tops;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hear"))
        {
            DropItem();
            SpawnEnemy.enemyNum--;
            Destroy(this.gameObject);
        }
    }
}