using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isMovePlane : MonoBehaviour
{
    static public bool isPlane = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MovePlane")) { isPlane = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.CompareTag("MovePlane")) { isPlane = false; }
    }
}
