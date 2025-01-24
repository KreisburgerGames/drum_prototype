using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointVelocity : MonoBehaviour
{
    public Vector3 velocity { get; private set; }
    private Vector3 lastPos;

    void Update()
    {
        velocity = (lastPos - transform.position) / Time.deltaTime;
        lastPos = transform.position;
    }
}
