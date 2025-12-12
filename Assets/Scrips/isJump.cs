using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class isJump : MonoBehaviour
{
    static public bool Jump = true;
    bool tag;

    private void OnCollisionStay2D(Collision2D collision)
    {

        tag = collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MovePlane") || collision.gameObject.CompareTag("Platform");
        if (tag) { Jump = true; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        tag = collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MovePlane") || collision.gameObject.CompareTag("Platform");
        if (tag) { Jump = false; }
    }
}
