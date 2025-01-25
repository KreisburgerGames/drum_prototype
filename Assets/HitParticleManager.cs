using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleManager : MonoBehaviour
{
    public GameObject hitParticlePrefab;
    public int poolSize = 10;
    private List<GameObject> hitParticlesPool = new List<GameObject>();
    private int currentIndex;

    void Start()
    {
        SoundCollider.OnSoundCollisionEvent += HitParticle;
        for(int i = 0; i < poolSize; i++)
        {
            GameObject hitParticle = Instantiate(hitParticlePrefab, transform);
            hitParticlesPool.Add(hitParticle);
            hitParticle.SetActive(false);
        }
    }

    void OnDestroy()
    {
        SoundCollider.OnSoundCollisionEvent -= HitParticle;
    }

    private void HitParticle(SoundCollisionEvent soundCollision)
    {
        GameObject hitParticle = hitParticlesPool[currentIndex];
        hitParticle.SetActive(true);
        RandomizeParticleColor(soundCollision.obj.GetComponentInChildren<ParticleSystem>());
        hitParticle.transform.position = soundCollision.position;
        currentIndex++;
        if(currentIndex > poolSize - 1) currentIndex = 0;
    }

    private void RandomizeParticleColor(ParticleSystem particleSystem)
    {
        Color color = Color.HSVToRGB(Random.Range(0.00f, 1.00f), 1f, 1f);
        particleSystem.GetComponent<ParticleSystemRenderer>().material.color = color;
    }
}
