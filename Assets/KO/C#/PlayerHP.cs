using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public static int playerHP = 5;
    public static int dathNum = 0;

    void Update()
    {
        if (playerHP > 5)
        {
            playerHP = 5;
        }
        
        if (playerHP <= 0)
        {
            dathNum += 1;
            playerHP = 5;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //HPを1ずつ減少
            playerHP -= 1;

            // ぶつかってきた相手を破壊
            Destroy(other.gameObject);
            SpawnEnemy.enemyNum--;
        }
    }
}