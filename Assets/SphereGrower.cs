using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGrower : MonoBehaviour
{
    public float growSpeed;
    private ParticleSystem particleSystem;
    private SphereCollider sphereCollider;
    private ParticleSystem.ShapeModule shape;
    private float currentRadius;
    private List<SoundCollider> soundObjects = new List<SoundCollider>();

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        shape = particleSystem.shape;
        sphereCollider = GetComponent<SphereCollider>();
        foreach(SoundCollider soundCollider in FindObjectsOfType<SoundCollider>()) soundObjects.Add(soundCollider);
    }

    void Update()
    {
        currentRadius += Time.deltaTime * growSpeed;
        shape.radius = currentRadius;
        sphereCollider.radius = currentRadius;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SoundCollider>() != null)
        {
            other.gameObject.GetComponent<SoundCollider>().canPlay = true;
        }
        bool allPlayable = true;
        foreach(SoundCollider soundCollider in soundObjects)
        {
            if(!soundCollider.canPlay) allPlayable = false;
        }
        if(allPlayable) Destroy(gameObject);
    }
}
