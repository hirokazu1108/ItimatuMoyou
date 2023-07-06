using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject center;
    void Start()
    {
         
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.transform.position, Vector3.up, 35 * Time.deltaTime);
    }
}