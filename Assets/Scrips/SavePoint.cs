using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    static public Vector2 spp;
    private void OnTriggerStay2D(Collider2D collision)
    {
        spp=collision.transform.position;
    }
}
