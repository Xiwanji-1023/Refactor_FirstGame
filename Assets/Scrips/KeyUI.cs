using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    public List<TMP_Text> keyui;
    void Update()
    {
        ShowKey(PlayerMove.currentKey);
    }
    private void ShowKey(List<KeyCode> key)
    {
        for(int i = 0; i < 4; i++)
        {
            keyui[i].text = key[i].ToString();
        }
    }
}
