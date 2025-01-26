using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowManager : MonoBehaviour
{
    public float speed;
    public Color currentColor;
    public float alpha = 0.5f;

    void Update()
    {
        Color.RGBToHSV(currentColor, out float h, out float s, out float v);
        s = 1f;
        v = 1f;
        h += speed * Time.deltaTime;
        currentColor = Color.HSVToRGB(h, s, v);
        currentColor.a = alpha;
    }
}
