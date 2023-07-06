using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloths : MonoBehaviour
{
    public GameObject gameObject;
    public float moveTime = 1.0f;  // 移動時間
    float elapsedTime = 1.0f;         // 経過時間
    float rate;                     // 割合
    private float timeBetweenMove = 0.35f;
    private float timer;

    // 位置
    Vector3 preposition;            // 移動前位置
    Vector3 postposition;           // 移動後位置

    void Start()
    {
        Transform transform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        // タイマーの時間を動かす
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && timer > timeBetweenMove)
        {
            timer = 0.0f;
            preposition = transform.position;   // 移動前位置
            postposition = new Vector3(preposition.x - 10.0f, preposition.y, preposition.z);
        }

        if (Input.GetKey(KeyCode.A) && timer > timeBetweenMove)
        {
            timer = 0.0f;
            preposition = transform.position;   // 移動前位置
            postposition = new Vector3(preposition.x + 10.0f, preposition.y, preposition.z);
        }

        elapsedTime += Time.deltaTime;  // 経過時間の加算
        rate = Mathf.Clamp01(elapsedTime / moveTime);   // 割合計算

        // 移動
        gameObject.transform.position =  Vector3.Lerp(preposition, postposition, rate);
    }
}