using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    int highscore;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        Time.timeScale = 0f;
    }

    public void OnClickPlay()
    {
        Time.timeScale = 1;
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
