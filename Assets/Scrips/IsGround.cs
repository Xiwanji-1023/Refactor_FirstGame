using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IsGround : MonoBehaviour
{
     static public bool isGround = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")||collision.CompareTag("Platform"))
        {
            isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            isGround = false;
        }
    }

}
