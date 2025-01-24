using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{

    public AudioClip clip;

    public string title;

    
    private int sampleLength;

    Rigidbody rb;
    AudioSource audio;

    // Start is called before the first frame update
    public void Setup(string title, AudioClip clip)
    {
        //rb = gameObject.AddComponent<Rigidbody>();
        audio = gameObject.AddComponent<AudioSource>();

        //rb.isKinematic = false;
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        audio.spatialBlend = 1f;
        audio.playOnAwake = false;
        audio.loop = false;
        audio.clip = clip;
        this.clip = clip;
        this.title = title;

        audio.clip = TrimSilenceFromClip(audio.clip);
    }

    public AudioClip TrimSilenceFromClip(AudioClip originalClip)
    {
        float[] audioData = new float[originalClip.samples * originalClip.channels];
        originalClip.GetData(audioData, 0); // Get the audio data from the clip

        int startIndex = 0;
        int endIndex = audioData.Length - 1;

        // Find the start index (first non-zero sample)
        for (int i = 0; i < audioData.Length; i++)
        {
            if (Mathf.Abs(audioData[i]) > 0.1f)  // Adjust the threshold to detect silence
            {
                startIndex = i;
                break;
            }
        }

        // Find the end index (last non-zero sample)
        for (int i = audioData.Length - 1; i >= 0; i--)
        {
            if (Mathf.Abs(audioData[i]) > 0.1f)  // Adjust the threshold to detect silence
            {
                endIndex = i;
                break;
            }
        }

        // Calculate the new length after trimming
        int newSampleLength = endIndex - startIndex + 1;
        float[] trimmedData = new float[newSampleLength];

        // Copy the trimmed data
        System.Array.Copy(audioData, startIndex, trimmedData, 0, newSampleLength);

        // Create a new AudioClip with the trimmed data
        AudioClip trimmedClip = AudioClip.Create("TrimmedClip", newSampleLength, originalClip.channels, originalClip.frequency, false);
        trimmedClip.SetData(trimmedData, 0); // Set the trimmed audio data

        return trimmedClip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Detected collison for item " + name);
        if (audio.isPlaying)
            return;

        audio.Play();

        Debug.Log("Play clip for item " + name);
    }
}
