using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int MoveSpeed=10;
    public int JumpAbility = 5;
    private float MoveController;

    [Header("dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveController = UnityEngine.Input.GetAxisRaw("Horizontal");
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
                if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
                }
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
                }
            
            

        }
    }





}
