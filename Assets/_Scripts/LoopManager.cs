using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;

public class LoopManager : MonoBehaviour
{

    public static Action<int> OnStartRecording, OnStopRecording, OnStartPlayback, OnStopPlayback, CountdownStart;

    public static bool _isRecording;

    float recordElapsedTime = 0;

    List<RecordLoopTimeline> loops = new List<RecordLoopTimeline>(4);

    RecordLoopTimeline activeLoop;

    private AudioSource audioSource;
    public float countdownbpm = 100f;
    private float countdownSpb;
    public float firstBeatPitch = 1f;
    public float subBeatPitch = 0.75f;
    private bool isCounting = false;

    // Start is called before the first frame update
    void Start()
    {
        SoundCollider.OnSoundCollisionEvent += OnSoundCollision;
        loops = new List<RecordLoopTimeline>(4);
        for (int i = 0; i < 4; i++)
        {
            loops.Add(null);
        }
        audioSource = GetComponent<AudioSource>();
        countdownSpb = 60f / countdownbpm;
    }

    private void OnDestroy()
    {
        SoundCollider.OnSoundCollisionEvent -= OnSoundCollision;
    }

    public void StartRecording(int index)
    {
        if (_isRecording)
            return;

        if (loops[index] != null && loops[index].isPlaying)
            loops[index].Stop();

        _isRecording = true;
        activeLoop = new RecordLoopTimeline();
        recordElapsedTime = 0;
        OnStartRecording?.Invoke(index);
        Debug.Log("Start recordng");
    }

    //public void StopRecording()
    //{
    //    _isRecording = false;

    //    loops.Add(activeLoop);
    //    Debug.Log("Stop recording");
    //}

    public void StopRecording(int index)
    {
        _isRecording = false;

        activeLoop.duration = recordElapsedTime;
        loops[index] = activeLoop;
        OnStopRecording?.Invoke(index);
        Debug.Log("Stop recording with duration " + recordElapsedTime);
    }

    //public void ToggleRecording()
    //{
    //    if(_isRecording)
    //    {
    //        StopRecording();
    //    }
    //    else
    //    {
    //        StartRecording();
    //    }
    //}

    public void ToggleRecording(int index)
    {
        if (_isRecording)
        {
            StopRecording(index);
        }
        else
        {
            if(isCounting) return;
            isCounting = true;
            StartCoroutine(Countdown(index));
        }
    }

    public void TogglePlayback(int index)
    {
        RecordLoopTimeline timeline = loops[index];
        if (timeline.isPlaying)
        {
            timeline.Stop();
            OnStopPlayback?.Invoke(index);
        }
        else
        {
            timeline.Play();
            OnStartPlayback?.Invoke(index);
        }
    }

    IEnumerator Countdown(int index)
    {
        CountdownStart?.Invoke(index);
        audioSource.pitch = firstBeatPitch;
        audioSource.Play();
        yield return new WaitForSeconds(countdownSpb);
        audioSource.pitch = subBeatPitch;
        audioSource.Play();
        yield return new WaitForSeconds(countdownSpb);
        audioSource.Play();
        yield return new WaitForSeconds(countdownSpb);
        audioSource.Play();
        isCounting = false;
        StartRecording(index);
    }

    private void OnSoundCollision(SoundCollisionEvent collision)
    {
        if (_isRecording == false)
            return;

        activeLoop.Add(collision, recordElapsedTime);
        Debug.Log("Record collision event " + collision.collider.name + " at time " + recordElapsedTime);
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

        if(_isRecording)
            recordElapsedTime += Time.deltaTime;
    }
}

public class RecordLoopTimeline
{
    public DateTime startTime;
    public List<RecordHistoryEvent> timeline;
    public bool isPlaying;

    public float playbackTime;

    public float duration;// => (float)(timeline.Last().absoluteTime - timeline.First().absoluteTime).TotalSeconds;

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
        //duration = elapsedTime;
        Debug.Log("Stop playing loop with duration " + duration);
    }

    public void Add(SoundCollisionEvent collision, float elapsedTime)
    {
        RecordHistoryEvent record = new RecordHistoryEvent()
        {
            //absoluteTime = DateTime.Now,
            elapsedTime = elapsedTime,
            collision = collision,
        };
        timeline.Add(record);
    }
    
    //public float GetRelativeTime(RecordHistoryEvent record)
    //{
    //    return record.GetRelativeTime(startTime);
    //}

    public void PlayLoop(float deltaTime)
    {
        if (isPlaying == false)
            return;

        

        foreach(var record in timeline)
        {
            if(record.hasPlayed == false && playbackTime > record.elapsedTime/*GetRelativeTime(record)*/)
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
    //public DateTime absoluteTime;
    public SoundCollisionEvent collision;
    public bool hasPlayed;
    public float elapsedTime;

    //public float GetRelativeTime(DateTime startTime)
    //{
    //    return (float)(absoluteTime - startTime).TotalMilliseconds / 1000f;
    //}

    public void PlayRecord()
    {
        hasPlayed = true;
        SoundEffectManager.Play(collision);//(collision.collider.clip, collision.tag, collision.velocity, collision.position);
        Debug.Log("Play record " + collision.collider.name + " at time " + elapsedTime);
    }
}
