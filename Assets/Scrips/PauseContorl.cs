using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseContorl : MonoBehaviour
{
    bool isPause = false;
    Vector3 offScreenPos;
    Vector3 onScreenPos;
    Vector3 Pos;
    float Speed = 150;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        offScreenPos = new Vector3(0, this.transform.localPosition.y, 0);
        Pos = offScreenPos + this.transform.parent.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "StartScene")
        {
            InputPause();


            if (isPause && Vector3.Distance(rb.position, Pos) < 10.01f)
            {
                PasueAll();
            }
            else
            {
                MoveMenu();
            }
        }

    }

    private void InputPause()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause) {Pos= this.transform.parent.position; }
            else { Pos = offScreenPos + this.transform.parent.position; ResumeAll(); }
            
        }


    }
    private void PasueAll()
    {
        Time.timeScale = 0f;
        Debug.Log("ÓÎÏ·ÔÝÍ£");
    }
    private void ResumeAll()
    {
        Time.timeScale = 1f;
        Debug.Log("ÓÎÏ·»Ö¸´");
    }
    private void MoveMenu()
    {
        float t = Time.deltaTime;
        Vector3 newPosition = Vector3.MoveTowards(rb.position, Pos, Speed * t);
        rb.MovePosition(newPosition);
    }


}
