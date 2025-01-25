using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SoundGenerator : MonoBehaviour
{

    public static SoundGenerator instance;

    public string apiUrl = "https://api.elevenlabs.io/v1/sound-generation";

    public string apiKey = "sk_00cd41bb3bb4b5fcde268d4241c28baecad773dba553832e";

    public AudioClip testClip;

    public string testDescription;

    public string tag = "Fingertip";

    public float velocity = 1f;

    public bool useDebug = true;


    private void Awake()
    {
        instance = this;
    }

    [ContextMenu("Test")]
    public void Test()
    {
        StartCoroutine(GenerateSoundByte(testDescription, (result)=>testClip = result));
    }

    [ContextMenu("Play")]
    public void Play()
    {
        //AudioSource.PlayClipAtPoint(testClip, Vector3.zero);
        SoundEffectManager.Play(testClip, tag, velocity, Vector3.zero);
    }

    public void TestAudioClip(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, Vector3.zero, 1f);
    }

    public static void GenerateSound(string text, Action<AudioClip> onResult)
    {
        string prompt = "One hit on a drum that sounds like a " + text;
        if (instance.useDebug && Application.isEditor)
        {
            onResult?.Invoke(instance.testClip);
        }
        else
        {
            instance.StartCoroutine(instance.GenerateSoundByte(text, onResult));
        }
    }

    IEnumerator GenerateSoundByte(string text, Action<AudioClip> onResult) 
    {
        // Create JSON body
        string requestBody = JsonUtility.ToJson(new SoundRequest(text));

        // Create UnityWebRequest
        UnityWebRequest webRequest = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(requestBody);
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerAudioClip(apiUrl, AudioType.MPEG);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("xi-api-key", apiKey);
        webRequest.SetRequestHeader("Accept", "audio/mpeg");

        // Send the request and wait for a response
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Sound generated successfully!");

            // Example: Handle the sound data (e.g., download and play it)
            //byte[] soundData = webRequest.downloadHandler.data;
            AudioClip clip = DownloadHandlerAudioClip.GetContent(webRequest);
            //Debug.Log("Retrieved byte array of length: " +  soundData.Length);
            onResult?.Invoke(clip);
            //PlaySoundFromData(soundData);
        }
        else
        {
            Debug.LogError($"Error: {webRequest.responseCode} - {webRequest.error}");
        }
    }

    public AudioClip GenerateSoundClip(byte[] bytes)
    {
        float[] samples = new float[bytes.Length * 4];

        Buffer.BlockCopy(bytes, 0, samples, 0, bytes.Length);

        int channels = 2; //Assuming audio is stereo or change to 1 if it's mono
        int sampleRate = 44100; //Assuming your samplerate is 44100 or change to 48000 or whatever is appropriate

        AudioClip clip = AudioClip.Create("ClipName", samples.Length, channels, sampleRate, false);
        clip.SetData(samples, 0);

        return clip;
    }


    [System.Serializable]
    public class SoundRequest
    {
        public string text;
        public double duration_seconds = 0.6; 

        public SoundRequest(string text)
        {
            this.text = text;
            duration_seconds = 0.6;
        }
    }
}
