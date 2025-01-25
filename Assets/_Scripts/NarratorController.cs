using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour
{

    public static NarratorController Instance { get; private set; }

    public Animator character;

    public AudioSource voiceover;

    public INarratorAction[] actions;


    private void Awake()
    {
        Instance = this;
        character.gameObject.SetActive(false);
        MagicDrumManager.OnRoomSetupComplete += OnRoomSetupComplete;
    }

    private void OnRoomSetupComplete()
    {
        MagicDrumManager.OnRoomSetupComplete -= OnRoomSetupComplete;
        character.gameObject.SetActive(true);
        StartCoroutine(PlayActions());
    }


    IEnumerator PlayActions()
    {
        foreach(var action in actions)
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
        controller.character.SetBool("IsTalking", true);
        controller.voiceover.clip = voiceover;
        controller.voiceover.Play();
        yield return new WaitWhile(()=>controller.voiceover.isPlaying);
        controller.character.SetBool("IsTalking", false);
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


    public IEnumerator DoAction(NarratorController controller)
    {
        yield return new WaitUntil(() => LoopManager._isRecording);
        yield return new WaitWhile(() => LoopManager._isRecording);
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