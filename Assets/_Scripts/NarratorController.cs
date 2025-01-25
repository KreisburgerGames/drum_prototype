using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NarratorController : MonoBehaviour
{

    public static NarratorController Instance { get; private set; }

    public Animator character;

    public AudioSource voiceover;

    public NarratorData data;

    public bool isStarted;

    private void Awake()
    {
        Instance = this;
        //character.gameObject.SetActive(false);
        MagicDrumManager.OnRoomSetupComplete += OnRoomSetupComplete;
        gameObject.SetActive(false);
    }

    private void OnRoomSetupComplete()
    {
        MagicDrumManager.OnRoomSetupComplete -= OnRoomSetupComplete;
        //character.gameObject.SetActive(true);
        isStarted = true;
        if(gameObject.activeSelf)StartCoroutine(PlayActions());
    }

    private void OnEnable()
    {
        if(isStarted)
            StartCoroutine(PlayActions());
    }


    IEnumerator PlayActions()
    {
        foreach(var action in data.actions)
        {
            yield return action.DoAction(this);
        }
    }


}

public interface INarratorAction
{

    public IEnumerator DoAction(NarratorController controller);

}

[System.Serializable]
public class NarratorSpeakAction : INarratorAction
{
    [TextArea]
    public string subtitle;
    public AudioClip voiceover;

    public IEnumerator DoAction(NarratorController controller)
    {
        SubtitleController.instance.Show(subtitle);
        controller.character.SetBool("IsTalking", true);
        if (voiceover != null)
        {
            controller.voiceover.clip = voiceover;
            controller.voiceover.Play();
            yield return new WaitWhile(() => controller.voiceover.isPlaying);
        }
        else
        {
            yield return new WaitForSeconds(3f);
        }
        controller.character.SetBool("IsTalking", false);
        SubtitleController.instance.Hide();
        yield return new WaitForSeconds(0.5f);
    }
}

[System.Serializable]
public class NarratorSetDanceAction : INarratorAction
{

    public bool isDancing;

    public IEnumerator DoAction(NarratorController controller)
    {
        controller.character.SetBool("IsDancing", isDancing);
        yield return null;
    }
}


[System.Serializable]
public class NarratorWaitForRecordAction : INarratorAction
{
    [SerializeReference, SubclassSelector]
    public INarratorAction idleAction;
    public float idleTime;

    public bool assertIsRecording;


    public IEnumerator DoAction(NarratorController controller)
    {
        //yield return new WaitUntil(() => LoopManager._isRecording);
        //yield return new WaitWhile(() => LoopManager._isRecording);
        float time = 0;
        while (LoopManager._isRecording != assertIsRecording)
        {
            if(time > idleTime && idleAction != null)
            {
                yield return idleAction.DoAction(controller);
                time = 0;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }
}

[System.Serializable]
public class NarratorWaitForCollisionAction : INarratorAction
{

    [SerializeReference, SubclassSelector]
    public INarratorAction idleAction;
    public float idleTime;

    //public bool assertIsRecording;
    bool hasCollided = false;

    public IEnumerator DoAction(NarratorController controller)
    {
        SoundCollider.OnSoundCollisionEvent += OnCollision;
        hasCollided = false;
        float time = 0;
        while (hasCollided == false)
        {
            if (time > idleTime && idleAction != null)
            {
                yield return idleAction.DoAction(controller);
                time = 0;
            }
            time += Time.deltaTime;
            yield return null;
        }
        SoundCollider.OnSoundCollisionEvent -= OnCollision;
    }

    private void OnCollision(SoundCollisionEvent @event)
    {
        hasCollided = true;
    }
}

[System.Serializable]
public class NarratorWaitForSecondsAction : INarratorAction
{

    public float seconds;

    public IEnumerator DoAction(NarratorController controller)
    {
        yield return new WaitForSeconds(seconds);
    }
}