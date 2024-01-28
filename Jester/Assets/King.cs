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
        StopText();
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
