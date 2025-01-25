using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;

public class LoopManager : MonoBehaviour
{

    bool _isRecording;

    List<RecordLoopTimeline> loops;

    RecordLoopTimeline activeLoop;

    // Start is called before the first frame update
    void Start()
    {
        SoundCollider.OnSoundCollisionEvent += OnSoundCollision; 
    }

    private void OnDestroy()
    {
        SoundCollider.OnSoundCollisionEvent -= OnSoundCollision;
    }

    public void StartRecording()
    {
        _isRecording = true;
        activeLoop = new RecordLoopTimeline();
    }

    public void StopRecordinig()
    {
        _isRecording = false;

        loops.Add(activeLoop);
    }

    private void OnSoundCollision(SoundCollisionEvent collision)
    {
        if (_isRecording == false)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var loop in loops)
        {
            if (loop.isPlaying)
            {
                loop.PlayLoop(Time.deltaTime);
            }
        }
    }
}

public class RecordLoopTimeline
{
    public DateTime startTime;
    public List<RecordHistoryEvent> timeline;
    public bool isPlaying;

    public float playbackTime;

    public float duration => (float)(timeline.Last().absoluteTime - timeline.First().absoluteTime).TotalMilliseconds / 1000f;

    public RecordLoopTimeline()
    {
        timeline = new List<RecordHistoryEvent>();
    }
    
    public void Play()
    {
        RestartLoop();
        isPlaying = true;
    } 

    public void Stop()
    {
        isPlaying = false;
    }
    
    public float GetRelativeTime(RecordHistoryEvent record)
    {
        return record.GetRelativeTime(startTime);
    }

    public void PlayLoop(float deltaTime)
    {
        if (isPlaying == false)
            return;

        

        foreach(var record in timeline)
        {
            if(record.hasPlayed == false && playbackTime > GetRelativeTime(record))
            {
                record.PlayRecord();
            }
        }

        playbackTime += deltaTime;

        if(playbackTime > duration)
        {
            RestartLoop();
        }
    }

    public void RestartLoop()
    {
        foreach(var record in timeline)
        {
            record.hasPlayed = false;
        }
        playbackTime = 0;
    }

}

public class RecordHistoryEvent
{
    public DateTime absoluteTime;
    public SoundCollisionEvent collision;
    public bool hasPlayed;

    public float GetRelativeTime(DateTime startTime)
    {
        return (float)(absoluteTime - startTime).TotalMilliseconds / 1000f;
    }

    public void PlayRecord()
    {
        hasPlayed = true;
        SoundEffectManager.Play(collision.collider.clip, collision.tag, collision.velocity, collision.position);
    }
}
