using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{

    public static Action<SoundCollisionEvent> OnSoundCollisionEvent;

    public Action<SoundCollisionEvent> OnCollision;

    public AudioClip clip;

    public string title;

    string rightTag, leftTag;
    
    private int sampleLength;

    Rigidbody rb;

    public bool canPlay = false;

    public ParticleSystem particleSystem;
    private bool activated = false;
    //AudioSource audio;

    // Start is called before the first frame update
    public void Setup(string title, AudioClip clip)
    {
        //rb = gameObject.AddComponent<Rigidbody>();
        //audio = gameObject.AddComponent<AudioSource>();

        //rb.isKinematic = false;
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        //audio.spatialBlend = 1f;
        //audio.playOnAwake = false;
        //audio.loop = false;
        //audio.clip = clip;
        this.clip = TrimSilenceFromClip(clip);
        this.title = title;

        //audio.clip = 
    }

    void Update()
    {
        if(!activated)
        {
            if(particleSystem != null && canPlay)
            {
                particleSystem.gameObject.SetActive(true);
                activated = true;
            }
        }
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

        endIndex = audioData.Length - 1;

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

    //private void FixedUpdate()
    //{
    //    leftTag = null;
    //    rightTag = null;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Detected collison for item " + name + " with " + collision.collider.name);
        //if (audio.isPlaying)
        //    return;

        //audio.PlayOneShot(audio.clip, 1f);
        if(!canPlay) return;

        if (collision.collider.TryGetComponent(out JointVelocity jv)) {

            if(!collision.collider.gameObject.GetComponentInParent<OVRHand>().IsTracked) return;

            //if(leftTag != null && jv.isRightHand == false)
            //{
            //    if (collision.collider.CompareTag(leftTag) == false)
            //        return;
            //}
            //if (rightTag != null && jv.isRightHand == true)
            //{
            //    if (collision.collider.CompareTag(rightTag) == false)
            //        return;
            //}

            float handVelocity = jv.velocity.magnitude;

            if (handVelocity < 0.1f)
                return;

            //(clip, collision.collider.tag, velocity, collision.GetContact(0).point);

            SoundCollisionEvent e = new SoundCollisionEvent()
            {
                collider = this,
                velocity = handVelocity,
                tag = collision.collider.tag,
                position = collision.GetContact(0).point
            };

            print(e.tag);

            SoundEffectManager.Play(e);

            OnCollision?.Invoke(e);
            OnSoundCollisionEvent?.Invoke(e);

            Debug.Log("Play clip for item " + name);

            //if(jv.isRightHand)
            //    rightTag = collision.collider.tag;
            //else
            //    leftTag = collision.collider.tag;
        }
    }
}


public class SoundCollisionEvent
{
    public SoundCollider collider;
    public float velocity;
    public string tag;
    public Vector3 position;
}
