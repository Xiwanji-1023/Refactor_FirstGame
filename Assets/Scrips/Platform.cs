using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Update is called once per frame
    private GameObject currentPlatformCollider;
    public BoxCollider2D PlayerCollider;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentPlatformCollider != null)
            {
                StartCoroutine(DownFromPlatform());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            currentPlatformCollider= collision.gameObject;
        }

    }
    //private void OnCollisionExit2D(Collision collision)
    //{
//<<<<<<< HEAD
    //    if(collision.gameObject.CompareTag("Platform"))
//=======
    //    if (collision.gameObject.CompareTag("Platform"))
//>>>>>>> 479c402fc3d81b63412c5063c861d6ef14c4253c
    //    {
    //        currentPlatformCollider = null;
    //    }
    //}
    private IEnumerator DownFromPlatform()
    {
        BoxCollider2D platformCollider = currentPlatformCollider.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(PlayerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(PlayerCollider, platformCollider, false);
    }
}
