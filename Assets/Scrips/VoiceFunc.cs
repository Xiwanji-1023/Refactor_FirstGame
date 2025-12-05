using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VoiceFunc : MonoBehaviour
{
    [Header("声音相关函数 需要什么函数即传入相应组件")]
    public Scrollbar bar = null;
    public TMP_InputField InputText = null;
    public Toggle BGMtoggle = null;
    public Toggle SoundToggle = null;

    public void ScrollVoice()
    {
        InputText.text = Mathf.RoundToInt(bar.value*100).ToString();
        BaseSetting.VoiceVolume = bar.value;
    }

    public void TextVoice()
    {
        try
        {
            if(string.IsNullOrEmpty(InputText.text)) { bar.value = 0.0f; return; }
            bar.value = Convert.ToInt16(InputText.text)/100.0f;
        }
        catch
        {
            Debug.Log("不输入数字是何意味");
        }
    }
    public void BGM()
    {
        BaseSetting.BackGroundMusic = BGMtoggle.isOn;
    }
    public void Sound()
    {
        BaseSetting.Sound = SoundToggle.isOn;
    }

}
