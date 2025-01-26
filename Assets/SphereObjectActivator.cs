using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereObjectActivator : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject fairy;
    public float growSpeed;
    void Start()
    {
        SphereGrow.startSphere += SphereGrowActivate;
    }

    void OnDestroy()
    {
        SphereGrow.startSphere -= SphereGrowActivate;
    }

    private void SphereGrowActivate()
    {
        GameObject sphere = Instantiate(spherePrefab);
        sphere.transform.position = fairy.transform.position;
        sphere.GetComponent<SphereGrower>().growSpeed = growSpeed;
    }
}
