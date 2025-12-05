using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMenu : MonoBehaviour
{
    public Rigidbody2D CurrentMenu;
    public Rigidbody2D TargetMenu;
    public RectTransform canvas;
    public bool isInit = false;
    Vector2 CurrentPos;
    Vector2 TargetPos;
    Vector2 deltaPos;

    bool isMove = false;

    void Start()
    {
        deltaPos = new Vector2(0, canvas.rect.height * 1.5f);
        if(isInit) { TargetMenu.position = CurrentMenu.position + deltaPos; }

    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            CurrentMenu.MovePosition(TargetPos);
            TargetMenu.MovePosition(CurrentPos);
            if (Vector2.Distance(CurrentMenu.position, TargetPos) < 0.1f && Vector2.Distance(TargetMenu.position, CurrentPos) < 0.1f)
            {
                isMove = false;
            }
        }
    }
    public void ChangeMenu()
    {

        CurrentPos = CurrentMenu.position;
        TargetPos = TargetMenu.position;
        isMove = true;
    }
}
