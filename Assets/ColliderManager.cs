using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void EnableCollider()
    {
        boxCollider.enabled = true;
        meshRenderer.enabled = true;
    }

    public void DisableCollider()
    {
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
    }
}
