using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseContorl : MonoBehaviour
{
    public bool isOn =false;
    void Update()
    {
        if (isOn && SceneManager.GetActiveScene().name != "StartScene" && Input.GetKeyDown(KeyCode.Escape))
        {
            InputPause();
        }
    }

    public void InputPause()
    {
        StartCoroutine(Pause());
    }
    IEnumerator Pause()
    {
        var scr = GetComponent<changeMenu>();
        BaseSetting.isPause = !BaseSetting.isPause;

        if (!BaseSetting.isPause) { ResumeAll(); }
        scr.Change();
        if (BaseSetting.isPause) { yield return new WaitForSeconds(0.2f); PasueAll(); }
    }
    private void PasueAll()
    {
        Time.timeScale = 0f;
        Debug.Log("”Œœ∑‘›Õ£");
    }
    private void ResumeAll()
    {
        Time.timeScale = 1f;
        Debug.Log("”Œœ∑ª÷∏¥");
    }


}
