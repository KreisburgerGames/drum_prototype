using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoopTrackController : MonoBehaviour
{

    public PokeInteractable recordButton, playButton;

    public GameObject stopRecordIcon, countdownIcon;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        LoopManager.OnStartPlayback += OnStartPlayback;
        LoopManager.OnStopPlayback += OnStopPlayback;
        LoopManager.OnStartRecording += OnStartRecording;
        LoopManager.OnStopRecording += OnStopRecording;
        LoopManager.CountdownStart += OnCountdownStart;

        Setup();
    }

    private void OnDestroy()
    {
        LoopManager.OnStartPlayback -= OnStartPlayback;
        LoopManager.OnStopPlayback -= OnStopPlayback;
        LoopManager.OnStartRecording -= OnStartRecording;
        LoopManager.OnStopRecording -= OnStopRecording;
        LoopManager.CountdownStart -= OnCountdownStart;
    }

    void Setup()
    {
        playButton.gameObject.SetActive(false);
        stopRecordIcon.gameObject.SetActive(false);
    }

    private void OnCountdownStart(int obj)
    {
        if(obj == index)
        {
            //recordButton.GetComponentInChildren<TMP_Text>().text = "[]";
            countdownIcon.SetActive(true);
            playButton.gameObject.SetActive(false);
        }
        else
        {
            countdownIcon.SetActive(false);
            recordButton.gameObject.SetActive(false);
        }
    }

    private void OnStartPlayback(int obj)
    {
        if (obj != index)
            return;
        playButton.GetComponentInChildren<TMP_Text>().text = "Stop";
    }

    private void OnStopPlayback(int obj)
    {
        if (obj != index)
            return;
        playButton.GetComponentInChildren<TMP_Text>().text = "Play";
    }

    private void OnStartRecording(int obj)
    {
        if(obj == index)
        {
            //recordButton.GetComponentInChildren<TMP_Text>().text = "[]";
            countdownIcon.SetActive(false);
            stopRecordIcon.SetActive(true);
            playButton.gameObject.SetActive(false);
        }
        else
        {
            recordButton.gameObject.SetActive(false);
        }
    }

    private void OnStopRecording(int obj)
    {
        if (obj == index)
        {
            //recordButton.GetComponentInChildren<TMP_Text>().text = "O";
            stopRecordIcon.SetActive(false);
            playButton.gameObject.SetActive(true);
        }
        else
        {
            recordButton.gameObject.SetActive(true);
        }
    }
}
