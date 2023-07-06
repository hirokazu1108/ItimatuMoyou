using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class TimeCounter : MonoBehaviour
{
    
    //カウントダウン
    public float countdown = 5.0f;
 
    //時間を表示するText型の変数
    public Text timeText;
 
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;
 
        //時間を表示する
        timeText.text = "制限時間：" + countdown.ToString("f1") + "秒\n" + "HP：" + PlayerHP.playerHP;
 
        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            this.GetComponent<SaveManager>().OnSave();
            SceneManager.LoadScene("Result");
        }

        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("TiTle");
        }
    }
}