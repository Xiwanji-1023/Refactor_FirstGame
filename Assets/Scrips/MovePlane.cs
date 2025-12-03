using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    [Tooltip("移动轴 0为x 1为y 2为斜上 3为斜下")]
    public int MoveAxis = 0;

    public float MoveSpeed = 0;
    public float ChangeTime = 2;
    Vector2 dir;
    Vector2 LastPos;
    Vector2 deltaPos;
    Transform tra;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        switch (MoveAxis)
        {
            case 0: dir = new Vector2(1, 0); break;
            case 1: dir = new Vector2(0, 1); break;
            case 2: dir = new Vector2(1, 1); break;
            case 3: dir = new Vector2(1, -1); break;
        }
        InvokeRepeating("changeDir", ChangeTime/2, ChangeTime);

        rb = GetComponent<Rigidbody2D>();
        rb.position = this.transform.position;
        LastPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveSpeed != 0)
        {
            float t = Time.deltaTime;
            Vector2 targetPos = rb.position + (dir * MoveSpeed * t);
            rb.MovePosition(targetPos);
            deltaPos = rb.position - targetPos;
            LastPos = rb.position;

        }
    }

    private void changeDir()
    {
        dir *= -1;
    }
//<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent=transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
//=======

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(deltaPos);
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D PlayerRb = collision.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
            if(PlayerRb != null)
            {
                Vector3 TargetPos = new Vector3(PlayerRb.position.x - deltaPos.x, PlayerRb.position.y + deltaPos.y, 0);
                PlayerRb.MovePosition(TargetPos);

            }
        }

    }
}

