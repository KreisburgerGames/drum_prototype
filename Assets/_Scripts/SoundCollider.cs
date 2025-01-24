using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{

    public AudioClip clip;

    public string title;

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
