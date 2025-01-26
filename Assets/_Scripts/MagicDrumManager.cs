using Meta.XR.MRUtilityKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicDrumManager : MonoBehaviour
{
    public GameObject hittableObjectParticlePrefab;

    public static Action OnRoomSetupComplete;

    public static string Genre;

    // Start is called before the first frame update
    void Start()
    {
        Genre = null;
        StartCoroutine(SetupMagicDrumScene());
    }

    public void SetGenre(string genre)
    {
        Genre = genre;
    }

    IEnumerator SetupMagicDrumScene()
    {
        yield return new WaitUntil(() => MRUK.Instance.IsInitialized);

        yield return new WaitUntil(() => Genre != null);

        MRUKAnchor[] anchors = FindObjectsOfType<MRUKAnchor>();
        foreach (MRUKAnchor anchor in anchors)
        {

            Collider collider = anchor.GetComponentInChildren<Collider>();

            if(collider == null)
                continue;

            string label = anchor.Label.ToString();
            Debug.Log("Generate audio for label " +  label);
            SoundGenerator.GenerateSound(label, (result)=>collider.gameObject.AddComponent<SoundCollider>().Setup(label, result));

            GameObject HOP = Instantiate(hittableObjectParticlePrefab);
            HOP.transform.position = anchor.GetComponentInChildren<MeshFilter>().gameObject.transform.position;
            HOP.transform.SetParent(anchor.gameObject.GetComponentInChildren<MeshFilter>().gameObject.transform);
            anchor.GetComponentInChildren<MeshRenderer>().enabled = false;
            ParticleSystem ps = HOP.GetComponent<ParticleSystem>();
            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Mesh;
            shape.mesh = anchor.GetComponentInChildren<MeshFilter>().mesh;
            HOP.GetComponentInParent<SoundCollider>().particleSystem = ps;
            HOP.SetActive(false);
        }

        OnRoomSetupComplete?.Invoke();
    }

}
