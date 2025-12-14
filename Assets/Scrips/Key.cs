using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public List<RawImage> keyui;
    public List<Texture> texture;
    private void Start()
    {
        ShowKey(new List<KeyCode>{ KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D,});
    }
    private void ShowKey(List<KeyCode> key)
    {
        for(int i = 0; i < keyui.Count; i++)
        {
            keyui[i].texture = texture[Convert.ToInt16(key[i]) - 97];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KeyChange"))
        {
            GameObject.Destroy(collision.gameObject);
            PlayerMove.currentKeyIndex = (PlayerMove.currentKeyIndex + 1) % 4;
            PlayerMove.currentKey = PlayerMove.key[PlayerMove.currentKeyIndex];
            PlayerMove.MoveController = 0;
            ShowKey(PlayerMove.currentKey);
        }
    }
}
