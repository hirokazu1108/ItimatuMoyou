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

        bgmSlider.value = bgmVolume; //BGM�X���C�_�[�̌��ݒl�̐ݒ�
        sensitivitySlider.value = sebsitibity; //���x�X���C�_�[�̌��ݒl�̐ݒ�
    }

    private void Update()
    {
        bgmVolume = bgmSlider.value;    //BGM�X���C�_�[�̌��ݒl��bgm�̑傫���Ɋi�[
        sebsitibity = sensitivitySlider.value;  //���x�X���C�_�[�̌��ݒl�����x�̑傫���Ɋi�[
    }
}
