using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = Option.bgmVolume;  //bgmの大きさを設定
    }
}
