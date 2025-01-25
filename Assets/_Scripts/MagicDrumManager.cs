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


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupMagicDrumScene());
    }



    IEnumerator SetupMagicDrumScene()
    {
        yield return new WaitUntil(() => MRUK.Instance.IsInitialized);

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
            anchor.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        OnRoomSetupComplete?.Invoke();
    }

}
