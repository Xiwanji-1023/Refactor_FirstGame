using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int MoveSpeed=10;
    public int JumpAbility = 5;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
        }
    }

}
