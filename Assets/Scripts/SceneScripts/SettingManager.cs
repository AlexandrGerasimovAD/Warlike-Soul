using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public void getSliderValue()
    {
     var _slider=  GameObject.Find("SliderCameraSpeedX").GetComponent<Slider>();
        if (PlayerPrefs.GetFloat("settingSliderValue") != 0)
        {
            _slider.value = PlayerPrefs.GetFloat("settingSliderValue");
        }
        else
        {
            _slider.value = 0.5f;
        }
    }
    public void setSliderValue()
    {
        var _slider = GameObject.Find("SliderCameraSpeedX").GetComponent<Slider>();
        PlayerPrefs.SetFloat("settingSliderValue", _slider.value);
        if (_slider.value > 0.5&&_slider.value<=0.6)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 105);
        }
        if (_slider.value > 0.6 && _slider.value <= 0.7)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 110);
        }
        if (_slider.value > 0.7 && _slider.value <= 0.8)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 115);
        }
        if (_slider.value > 0.8 && _slider.value <= 1)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 120);
        }
        if (_slider.value > 0.4 && _slider.value <= 0.49)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 95);
        }
        if (_slider.value > 0.3 && _slider.value <= 0.4)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 90);
        }
        if (_slider.value > 0.2 && _slider.value <= 0.3)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 85);
        }
        if (_slider.value > 0.1 && _slider.value <= 0.2)
        {
            PlayerPrefs.SetInt("cameraSpeedX", 80);
        }
        if (_slider.value == 0 )
        {
            PlayerPrefs.SetInt("cameraSpeedX", 80);
        }
    }
}
