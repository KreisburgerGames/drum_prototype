using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private RainbowManager rainbowManager;

    void Start()
    {
        rainbowManager = FindFirstObjectByType<RainbowManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.material.color = rainbowManager.currentColor;
    }

    void Update()
    {
        meshRenderer.material.color = rainbowManager.currentColor;
    }
}
