using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class mymove : MonoBehaviour
{
    private Rigidbody2D rb;
 
    [SerializeField] private float xinput;
    [SerializeField] private float movespeed;
    [SerializeField] private float highspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xinput = UnityEngine.Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xinput * movespeed, rb.velocity.y);

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, highspeed);
        }
    }
}
