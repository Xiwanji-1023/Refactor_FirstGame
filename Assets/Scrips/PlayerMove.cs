using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class PlayerMove : MonoBehaviour
{
    public string nowKeys;
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int MoveSpeed = 10;
    public int JumpAbility = 5;
    private float MoveController;
    static public bool W, A, S, D, I, J, K, L;

    [Header("dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //MoveController = UnityEngine.Input.GetAxisRaw("Horizontal");
        switch (nowKeys)
        {
            case "wdjk":
                A = false;
                S = false;
                W = true;
                D = true;
                J = true;
                K = true;
                I = false;
                L = false;
                break;
            case "awkl":
                A = true;
                S = false;
                W = true;
                D = false;
                J = false;
                K = true;
                I = false;
                L = true;
                break;
            case "ijsd":
                A = false;
                S = true;
                W = false;
                D = true;
                J = true;
                K = false;
                I = true;
                L = false;
                break;
            case "adik":
                A = true;
                S = false;
                W = false;
                D = true;
                J = false;
                K = true;
                I = true;
                L = false;
                break;


        }

        if (UnityEngine.Input.GetKey(KeyCode.A) && A)
        {
            MoveController = -1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.D) && D)
        {
            MoveController = 1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.J) && J)
        {
            MoveController = -1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.L) && L)
        {
            MoveController = 1;
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.A) && A)
        {
            MoveController = 0;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.D) && D)
        {
            MoveController = 0;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.J) && J)
        {
            MoveController = 0;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.L) && L)
        {
            MoveController = 0;
        }



        if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
        {
            dashTime = dashDuration;
        }
        dashTime -= Time.deltaTime;

        rb.velocity = new Vector2(MoveSpeed * MoveController, rb.velocity.y);
        if (IsGround.isGround || isMovePlane.isPlane)
        {
            if (dashTime > 0)
            {
                rb.velocity = new Vector2(MoveController * dashSpeed, rb.velocity.y);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.W)&&W)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.I)&&I)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
            }



        }
    }

}




