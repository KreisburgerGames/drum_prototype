using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour
{

    public static SubtitleController instance;


    public TMP_Text output;


    private void Awake()
    {
        instance = this;
        Hide();
    }


    public void Show(string text)
    {
        output.text = text;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
