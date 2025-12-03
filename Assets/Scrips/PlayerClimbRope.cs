using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbRope : MonoBehaviour
{
    public Rigidbody2D rb;
    private float ClimbController;
    public int ClimbSpeed=5;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        ClimbController = Input.GetAxisRaw("Vertical");
        if (collision.transform.CompareTag("Rope"))
        {

            if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                rb.velocity = new Vector2(0, ClimbSpeed * ClimbController);
            }
        }
    }
    
}
