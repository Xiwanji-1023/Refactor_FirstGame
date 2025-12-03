using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScenceButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GamingScene");
    }

    public void Setting()
    {

    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
}
