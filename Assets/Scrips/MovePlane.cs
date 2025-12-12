using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    [Tooltip("移动轴 0为x 1为y 2为斜上 3为斜下")]
    public int MoveAxis = 0;

    public float MoveSpeed = 0;
    public float ChangeTime = 2;
    Vector2 dir;
    Vector2 deltaPos = Vector2.zero;
    Vector2 lastPos;
    Transform tra;
    Rigidbody2D rb;
    void Start()
    {
        switch (MoveAxis)
        {
            case 0: dir = new Vector2(1, 0); break;
            case 1: dir = new Vector2(0, 1); break;
            case 2: dir = new Vector2(1, 1); break;
            case 3: dir = new Vector2(1, -1); break;
        }
        InvokeRepeating("changeDir", ChangeTime / 2, ChangeTime);

        rb = GetComponent<Rigidbody2D>();
        rb.position = this.transform.position;
        lastPos = rb.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveSpeed != 0)
        {
            float t = Time.deltaTime;
            Vector2 targetPos = rb.position + (dir * MoveSpeed * t);
            rb.MovePosition(targetPos);
        }
        deltaPos = rb.position - lastPos;
        lastPos = rb.position;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !Input.anyKey)
        {
            Rigidbody2D rbPlayer = collision.gameObject.GetComponent<Rigidbody2D>();
            rbPlayer.MovePosition(rbPlayer.position + deltaPos);
        }
    }
    private void changeDir()
    {
        dir *= -1;
    }
}
