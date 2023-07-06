using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf == false)
        {
            player.transform.position = new Vector3(-8.6f, -0.75f, -14.0f);
            player.SetActive(true);
        }
    }
}
