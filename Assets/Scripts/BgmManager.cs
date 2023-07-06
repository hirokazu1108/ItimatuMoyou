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
        audioSource.volume = Option.bgmVolume;  //bgm‚Ì‘å‚«‚³‚ğİ’è
    }
}
