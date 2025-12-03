using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Traps"))
        {
            //Dead Animation

            rb.bodyType = RigidbodyType2D.Static;
            //revive Animation

            transform.position = SavePoint.spp;
            rb.bodyType=RigidbodyType2D.Dynamic;
        }
    }
}
