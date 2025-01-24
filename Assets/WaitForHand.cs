using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForHand : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public GameObject leftPalmCollider;
    public GameObject rightPalmCollider;
    private bool isLeftPalmInit, isRightPalmInit = false;
    public Vector3 leftHandOffset, rightHandOffset;

    void Update()
    {
        if(!isLeftPalmInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_Palm") != null)
        {
            leftPalmCollider.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_Palm").transform;
            leftPalmCollider.transform.localPosition = leftHandOffset;
            leftPalmCollider.transform.localEulerAngles = Vector3.zero;
            isLeftPalmInit = true;
        }
        if(!isRightPalmInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_Palm") != null)
        {
            rightPalmCollider.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_Palm").transform;
            rightPalmCollider.transform.localPosition = rightHandOffset;
            rightPalmCollider.transform.localEulerAngles = Vector3.zero;
            isRightPalmInit = true;
        }
    }
}
