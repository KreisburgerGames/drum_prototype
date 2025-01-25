using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundEffectManager : MonoBehaviour
{

    static SoundEffectManager instance;

    [SerializeField]
    AudioSource prefab;

    public int poolSize = 10;

    List<AudioSource> activeSource = new List<AudioSource>();
    List<AudioSource> inactiveSource = new List<AudioSource>();

    public float maxVelocity;

    private void Awake()
    {
        Setup();
        instance = this;

    }

    void Setup()
    {
        if(prefab == null)
        {
            prefab = new GameObject("SFX Source").AddComponent<AudioSource>();
            prefab.transform.parent = transform;
            prefab.gameObject.SetActive(false);
        }

        prefab.playOnAwake = false;
        prefab.loop = false;
        prefab.spatialBlend = 1f;
        for (int i = 0; i < poolSize; i++)
        {
            AudioSource clone = Instantiate(prefab, transform);
            inactiveSource.Add(clone);
            clone.gameObject.SetActive(false);
        }
    }

    public static void Play(AudioClip clip, string tag, float velocity, Vector3 positon)
    {
        instance.PlayClip(clip, tag, velocity, positon);
    }

    public void PlayClip(AudioClip clip, string tag, float velocity, Vector3 position)
    {
        StartCoroutine(HandleAudioSource(clip, tag, velocity, position));
    }

    IEnumerator HandleAudioSource(AudioClip clip, string tag, float velocity, Vector3 position)
    {
        if (inactiveSource.Count == 0)
        {
            Debug.LogError("Can not play clip because we are out of sources!");
            yield break;
        }

        AudioSource source = inactiveSource[0];

        source.transform.position = position;

        source.clip = clip;
        switch (tag)
        {
            case "Palm":
                source.pitch = 0.5f;
                break;
            case "Fingertip":
                source.pitch = 1f;
                break;
            case "Knuckle":
                source.pitch = 1.5f;
                break;
        }
        source.volume = velocity / maxVelocity;

        Debug.Log($"Play clip at pitch {source.pitch} from {tag} tag and volume {source.volume} from {velocity} velocity");

        inactiveSource.Remove(source);
        activeSource.Add(source);

        source.gameObject.SetActive(true);

        source.Play();

        yield return new WaitWhile(() => source.isPlaying);

        source.gameObject.SetActive(false);
        activeSource.Remove(source);
        inactiveSource.Add(source);

    }
}
