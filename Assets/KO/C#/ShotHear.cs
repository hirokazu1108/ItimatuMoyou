using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHear : MonoBehaviour
{
    public float shotSpeed;
    private GameObject player;
    private GameObject camera;
    private float timeBetweenShot = 4.0f;
    private float timer = 0.0f;

    [SerializeField]
    private GameObject shellPrefab;

    void Start()
    {
        player = GameObject.Find("Player_com");
        camera = GameObject.Find("FPSCamera");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > timeBetweenShot)
        {
            timer = 0.0f;
            //Invoke("Make", 1.3f);
        }
    }

    private void Make()
    {
        GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
        shell.transform.parent = player.transform;
        shell.transform.parent = camera.transform;

        Rigidbody shellRb = shell.GetComponent<Rigidbody>();

        //shellRb.AddForce(transform.forward * shotSpeed);

        Destroy(shell, 1.7f);
    }
}