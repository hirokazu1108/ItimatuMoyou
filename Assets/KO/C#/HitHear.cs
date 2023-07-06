using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHear : MonoBehaviour
{
    public static float killNum = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hear"))
        {
            killNum += 1;
            // Destroy(this.gameObject);
        }
    }
}