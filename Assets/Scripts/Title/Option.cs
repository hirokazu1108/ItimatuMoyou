using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public static float bgmVolume = 0.3f;
    public static float sebsitibity = 1.0f;

    [SerializeField] GameObject bgmSliderObj;
    [SerializeField] GameObject sensitivitySliderObj;
    Slider bgmSlider;
    Slider sensitivitySlider;

    void Start()
    {
        bgmSlider = bgmSliderObj.GetComponent<Slider>();
        sensitivitySlider = sensitivitySliderObj.GetComponent<Slider>();

        bgmSlider.value = bgmVolume; //BGMスライダーの現在値の設定
        sensitivitySlider.value = sebsitibity; //感度スライダーの現在値の設定
    }

    private void Update()
    {
        bgmVolume = bgmSlider.value;    //BGMスライダーの現在値をbgmの大きさに格納
        sebsitibity = sensitivitySlider.value;  //感度スライダーの現在値を感度の大きさに格納
    }
}
