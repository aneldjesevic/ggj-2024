using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    [SerializeField] string[] firstWord;
    [SerializeField] Text text;
    [SerializeField] GameObject bubble;

    private void Start()
    {
        StartStartText();
    }

    void StartStartText()
    {
        bubble.SetActive(true);
        if (PlayerPrefs.GetInt("highscore") >= 1)
            text.text = "our best jester only got to " + (PlayerPrefs.GetInt("highscore"));
        else
            text.text = "our best jester only got to " + 1;
        Invoke("StopText", 2f);
    }

    public void StartText(int waveIndex)
    {
        bubble.SetActive(true);
        string randomFirstWord = firstWord[Random.Range(0, firstWord.Length)];
        text.text = randomFirstWord + " wave " + waveIndex.ToString();
        Invoke("StopText", 2f);
    }

    public void StopText()
    {
        bubble.SetActive(false);
    }
}
