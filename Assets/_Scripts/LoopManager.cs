using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;

public class LoopManager : MonoBehaviour
{

    public static Action<int> OnStartRecording, OnStopRecording, OnStartPlayback, OnStopPlayback;

    bool _isRecording;

    List<RecordLoopTimeline> loops = new List<RecordLoopTimeline>(4);

    RecordLoopTimeline activeLoop;

    // Start is called before the first frame update
    void Start()
    {
        SoundCollider.OnSoundCollisionEvent += OnSoundCollision;
        loops = new List<RecordLoopTimeline>(4);
        for (int i = 0; i < 4; i++)
        {
            loops.Add(null);
        }
    }

    private void OnDestroy()
    {
        SoundCollider.OnSoundCollisionEvent -= OnSoundCollision;
    }

    public void StartRecording()
    {
        if (_isRecording)
            return;

        _isRecording = true;
        activeLoop = new RecordLoopTimeline();
        Debug.Log("Start recordng");
    }

    public void StopRecording()
    {
        _isRecording = false;

        loops.Add(activeLoop);
        Debug.Log("Stop recording");
    }

    public void StopRecording(int index)
    {
        _isRecording = false;

        loops[index] = activeLoop;
        Debug.Log("Stop recording");
    }

    public void ToggleRecording()
    {
        if(_isRecording)
        {
            StopRecording();
        }
        else
        {
            StartRecording();
        }
    }

    public void ToggleRecording(int index)
    {
        if (_isRecording)
        {
            StopRecording(index);
        }
        else
        {
            StartRecording();
        }
    }

    public void TogglePlayback(int index)
    {
        RecordLoopTimeline timeline = loops[index];
        if (timeline.isPlaying)
        {
            timeline.Stop();
        }
        else
        {
            timeline.Play();
        }
    }

    private void OnSoundCollision(SoundCollisionEvent collision)
    {
        if (_isRecording == false)
            return;

        activeLoop.Add(collision);
        Debug.Log("Record collision event " + collision.collider.name);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var loop in loops)
        {
            if(loop == null) continue;
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
        startTime = DateTime.Now;
    }
    
    public void Play()
    {
        RestartLoop();
        isPlaying = true;
        Debug.Log("Start playing loop");
    } 

    public void Stop()
    {
        isPlaying = false;
        Debug.Log("Stop playing loop");
    }

    public void Add(SoundCollisionEvent collision)
    {
        RecordHistoryEvent record = new RecordHistoryEvent()
        {
            absoluteTime = DateTime.Now,
            collision = collision,
        };
        timeline.Add(record);
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
        Debug.Log("Play record " + collision.collider.name);
    }
}
