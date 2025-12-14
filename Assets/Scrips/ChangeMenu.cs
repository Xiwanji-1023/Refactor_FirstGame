using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class changeMenu : MonoBehaviour
{
    public RectTransform CurrentMenu;
    public RectTransform TargetMenu;
    public RectTransform canvas;
    public bool isInit = false;
    public float DurationAnimation = 0.1f;
    Vector2 CurrentPos;
    Vector2 TargetPos;
    Vector2 deltaPos;
    float t = 0;

    void Start()
    {
        if(isInit)
        {
            deltaPos = new Vector2(0, canvas.rect.height);
            //CurrentMenu.anchoredPosition = canvas.anchoredPosition;
            TargetMenu.anchoredPosition = CurrentMenu.anchoredPosition + deltaPos;
        }
    }

    public void Change()
    {
        if (!BaseSetting.isMenuAnimation) { BaseSetting.isMenuAnimation = true; StartCoroutine(ChangeMenu()); }

    }

    IEnumerator ChangeMenu()
    {

        CurrentPos = CurrentMenu.anchoredPosition;
        TargetPos = TargetMenu.anchoredPosition;
        float PassTime = 0f;
        while (PassTime < DurationAnimation)
        {
            PassTime += Time.unscaledDeltaTime;
            t = Mathf.Clamp01(PassTime/DurationAnimation);
            CurrentMenu.anchoredPosition = Vector2.Lerp(CurrentPos, TargetPos, t);
            TargetMenu.anchoredPosition = Vector2.Lerp(TargetPos, CurrentPos, t);
            yield return null;
        }

        CurrentMenu.anchoredPosition = TargetPos;
        TargetMenu.anchoredPosition = CurrentPos;
        BaseSetting.isMenuAnimation = false;
        
    }
}