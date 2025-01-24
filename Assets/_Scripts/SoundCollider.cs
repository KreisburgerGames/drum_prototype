using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{

    public AudioClip clip;

    Rigidbody rb;
    AudioSource audio;

    // Start is called before the first frame update
    public void Setup(AudioClip clip)
    {
        rb = gameObject.AddComponent<Rigidbody>();
        audio = gameObject.AddComponent<AudioSource>();

        rb.isKinematic = true;
        audio.spatialBlend = 1f;
        audio.playOnAwake = false;
        audio.loop = false;
        audio.clip = clip;
        this.clip = clip;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (audio.isPlaying)
            return;

        audio.Play();
    }
}
