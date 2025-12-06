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
        Debug.Log(BaseSetting.isPause);
        if (!BaseSetting.isPause) { ResumeAll(); }
        if (isOn && SceneManager.GetActiveScene().name != "StartScene" && Input.GetKeyDown(KeyCode.Escape))
        {
            InputPause();
        }
    }

    public void InputPause()
    {
        if (!BaseSetting.isMenuAnimation)
        {
            GetComponent<changeMenu>().Change();
            StartCoroutine(Pause());
        }
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }
    IEnumerator Pause()
    {
        BaseSetting.isPause = !BaseSetting.isPause;
        if (BaseSetting.isPause) { yield return new WaitForSeconds(0.2f); PasueAll(); }

    }
    private void PasueAll()
    {
        Time.timeScale = 0f;
    }
    private void ResumeAll()
    {
        Time.timeScale = 1f;
    }


}
