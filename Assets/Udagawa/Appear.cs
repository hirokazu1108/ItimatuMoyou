using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    [SerializeField] GameObject heal;
    [SerializeField] GameObject power;
    [SerializeField] GameObject speed;
    public float interval;
    private float time = 0f;
    private int random;

    // Start is called before the first frame update
    void Start()
    {
        heal.SetActive(false);
        power.SetActive(false);
        speed.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        

        if (time > interval)
        {
            random = Random.Range(1, 99);

            if (random <= 33)
            {
                heal.SetActive(true);
            }
            else if(random <= 66)
            {
                power.SetActive(true);
            }
            else
            {
                speed.SetActive(true);
            }
            
            time = 0f;
        }

    }
}
