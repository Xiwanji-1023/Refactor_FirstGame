using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int MoveSpeed = 10;
    public int JumpAbility = 5;
    public static float MoveController;
    //以下用于动画
    private bool isWalk;
    private Animator anim;
    private bool onSky;
    //
    private int facingdirection = 1;
    private bool faceRight = true;


    [Header("dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;

    static public List<KeyCode> currentKey;
    static public int currentKeyIndex = 0;
    static public Dictionary<int, List<KeyCode>> key;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        //以下用于动画
        anim = GetComponent<Animator>();
        //
        currentKey = new List<KeyCode>();
        key = new Dictionary<int, List<KeyCode>>()
        {
            [0] = new List<KeyCode>() { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, },
            [1] = new List<KeyCode>() { KeyCode.A, KeyCode.W, KeyCode.K, KeyCode.L, },
            [2] = new List<KeyCode>() { KeyCode.I, KeyCode.J, KeyCode.S, KeyCode.D, },
            [3] = new List<KeyCode>() { KeyCode.A, KeyCode.D, KeyCode.O, KeyCode.K, },
        };
        currentKey = key[currentKeyIndex];
    }
    void Update()
    {
   
        flipcontroller();
        if (Input.GetKey(currentKey[0]) && isJump.Jump)
        {
            if (dashTime > 0)
            {
                rb.velocity = new Vector2(MoveController * dashSpeed, rb.velocity.y);
            }
            rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
        }
        if (Input.GetKey(currentKey[1]))
        {
            MoveController = -1;
        }
        if (Input.GetKeyUp(currentKey[1]))
        {
            MoveController = 0;
        }
        if (Input.GetKey(currentKey[3]))
        {
            MoveController = 1;
        }
        if (Input.GetKeyUp(currentKey[3]))
        {
            MoveController = 0;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            dashTime = dashDuration;
        }
        dashTime -= Time.deltaTime;

        rb.velocity = new Vector2(MoveSpeed * MoveController, rb.velocity.y);


        //以下用于动画
        isWalk = rb.velocity.x != 0;
        anim.SetBool("iswalk", isWalk);
        if(rb.velocity.y>0.3f)
        {
            onSky = true;
        }
        else
        {
            onSky = false;
        }
        anim.SetBool("sky", onSky);
        //
        //MoveController = UnityEngine.Input.GetAxisRaw("Horizontal");
        //switch (nowKeys)
        //{
        //    case "wdjk":
        //        A = false;
        //        S = false;
        //        W = true;
        //        D = true;
        //        J = true;
        //        K = true;
        //        I = false;
        //        L = false;
        //        break;
        //    case "awkl":
        //        A = true;
        //        S = false;
        //        W = true;
        //        D = false;
        //        J = false;
        //        K = true;
        //        I = false;
        //        L = true;
        //        break;
        //    case "ijsd":
        //        A = false;
        //        S = true;
        //        W = false;
        //        D = true;
        //        J = true;
        //        K = false;
        //        I = true;
        //        L = false;
        //        break;
        //    case "adik":
        //        A = true;
        //        S = false;
        //        W = false;
        //        D = true;
        //        J = false;
        //        K = true;
        //        I = true;
        //        L = false;
        //        break;


        //}

        //if (UnityEngine.Input.GetKey(KeyCode.A) && A)
        //{
        //    MoveController = -1;
        //}
        //if (UnityEngine.Input.GetKey(KeyCode.D) && D)
        //{
        //    MoveController = 1;
        //}
        //if (UnityEngine.Input.GetKey(KeyCode.J) && J)
        //{
        //    MoveController = -1;
        //}
        //if (UnityEngine.Input.GetKey(KeyCode.L) && L)
        //{
        //    MoveController = 1;
        //}

        //if (UnityEngine.Input.GetKeyUp(KeyCode.A) && A)
        //{
        //    MoveController = 0;
        //}
        //if (UnityEngine.Input.GetKeyUp(KeyCode.D) && D)
        //{
        //    MoveController = 0;
        //}
        //if (UnityEngine.Input.GetKeyUp(KeyCode.J) && J)
        //{
        //    MoveController = 0;
        //}
        //if (UnityEngine.Input.GetKeyUp(KeyCode.L) && L)
        //{
        //    MoveController = 0;
        //}



        //if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
        //{
        //    dashTime = dashDuration;
        //}
        //dashTime -= Time.deltaTime;

        //rb.velocity = new Vector2(MoveSpeed * MoveController, rb.velocity.y);
        //if (IsGround.isGround || isMovePlane.isPlane)
        //{
        //    if (dashTime > 0)
        //    {
        //        rb.velocity = new Vector2(MoveController * dashSpeed, rb.velocity.y);
        //    }
        //    if (UnityEngine.Input.GetKeyDown(KeyCode.W)&&W)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
        //    }
        //    if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
        //    }
        //    if (UnityEngine.Input.GetKeyDown(KeyCode.I)&&I)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
        //    }
        //}
    }

    // wdjk
    // awkl
    // ijsd
    // adok



    private void flip()
    {
        facingdirection = facingdirection * -1;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }
    private void flipcontroller()
    {
        if (rb.velocity.x > 0 && !faceRight)
        {
            flip();
        }
        else if (rb.velocity.x < 0 && faceRight)
        {
            flip();
        }
    }
}




