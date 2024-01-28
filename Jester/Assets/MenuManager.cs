using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    int highscore;
    [SerializeField] GameObject playerSlider;
    void Start()
    {
        playerSlider.SetActive(false);
        highscore = PlayerPrefs.GetInt("highscore");
        Time.timeScale = 0f;
    }

    public void OnClickPlay()
    {
        Time.timeScale = 1;

        Invoke("EnablePlayerSlider", 1f);
    }
    void EnablePlayerSlider()
    {
        playerSlider.SetActive(true);
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
