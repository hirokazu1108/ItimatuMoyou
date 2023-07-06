using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    //===== 定義領域 =====
    private Animator anim;  //Animatorをanimという変数で定義する
    public GameObject shot;
    private GameObject player;
    private GameObject camera;
    [SerializeField]
    private GameObject shellPrefab;
    private float timeBetweenShot = 3.0f;
    private float timer = 0.0f;

    //===== 初期処理 =====
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player_com");
        camera = GameObject.Find("FPSCamera");
        anim.keepAnimatorControllerStateOnDisable = true;
    }

    //===== 主処理 =====
    void Update()
    {
        timer += Time.deltaTime;
        //もし、スペースキーが押されたらなら
        if (Input.GetKey(KeyCode.Space) && timer > timeBetweenShot)
        {
            timer = 0.0f;
            //Bool型のパラメーターであるblRotをTrueにする
            anim.SetTrigger("Trigger");
            Invoke("Make", 1.2f);
        }
    }

    private void Make()
    {
        Vector3 posi = shot.transform.position;
        GameObject shell = Instantiate(shellPrefab, shot.transform.position, Quaternion.identity);
        shell.transform.parent = player.transform;
        shell.transform.parent = camera.transform;

        Rigidbody shellRb = shell.GetComponent<Rigidbody>();

        Destroy(shell, 1.7f);
    }
}