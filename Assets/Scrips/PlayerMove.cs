using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int MoveSpeed=10;
    public int JumpAbility = 5;
    private float MoveController;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (IsGround.isGround)
        {
            if (IsGround.isGround || isMovePlane.isPlane)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpAbility);
                }
            }
            
        }
        MoveController = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveSpeed * MoveController, rb.velocity.y);
        rb.velocity = new Vector2(MoveSpeed * MoveController, rb.velocity.y);
    }


}
