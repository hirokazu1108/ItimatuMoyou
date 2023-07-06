using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarEnemy : MonoBehaviour
{
    private Transform target;

    void Update()
    {
        target = GameObject.Find("Target_nav").transform;
        transform.root.LookAt(target);
    }
}
