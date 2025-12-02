using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidBody;
    protected Vector2 upLeft = new Vector2(1,1);
    protected Vector2 upRight = new Vector2(-1, 1);
    public float ForceLeft = 100;
    public float ForceRight = 100;
    public int WaitForce = 500;
    public int ForceThreshold = 500;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            rigidBody.AddForce(upLeft * ForceRight);
            ForceRight = 100;
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (ForceRight <= ForceThreshold)
            {
                ForceRight += WaitForce * Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            rigidBody.AddForce(upRight * ForceLeft);
            ForceLeft = 100;
        }
        if (Input.GetKey(KeyCode.J))
        {
            if(ForceLeft<=ForceThreshold)
            {
                ForceLeft += WaitForce * Time.deltaTime;
            }
        }
    }
    
}
