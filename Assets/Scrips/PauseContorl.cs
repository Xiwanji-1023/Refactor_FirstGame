using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseContorl : MonoBehaviour
{
    bool isPause = false;
    Vector2 offScreenPos;
    Vector2 Pos;
    Vector2 CameraPos;
    float Speed = 500;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offScreenPos = new Vector3(0, 20.5f);
        CameraPos = this.transform.parent.gameObject.GetComponent<Rigidbody2D>().position;
        Pos = CameraPos + offScreenPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "StartScene")
        {
            InputPause();
        }
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name != "StartScene")
        {
            MoveMenu();
            if (Vector2.Distance(rb.position, CameraPos) <0.1f && isPause) { PasueAll(); }
        }
    }

    private void InputPause()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (!isPause) { ResumeAll(); }
            
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
        CameraPos = this.transform.parent.gameObject.GetComponent<Rigidbody2D>().position;
        Pos = CameraPos + ((!isPause)?offScreenPos:Vector2.zero);
        float t = Time.deltaTime;
        Vector3 newPosition = Vector3.MoveTowards(rb.position, Pos, Speed * t);
        rb.MovePosition(newPosition);
    }


}
