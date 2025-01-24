using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForHand : MonoBehaviour
{
    public GameObject leftPalmCollider, leftThumb, leftIndex /*INDEX??? VALVE REFERENCE*/, leftMiddle, leftRing, leftLittle;
    public GameObject rightPalmCollider, rightThumb, rightIndex /*uhhh can't make another reference*/, rightMiddle, rightRing, rightLittle;
    private bool isLeftPalmInit, isLeftThumbInit, isLeftIndexInit, isLeftMiddleInit, isLeftRingInit, isLeftLittleInit = false;
    private bool isRightPalmInit, isRightThumbInit, isRightIndexInit, isRightMiddleInit, isRightRingInit, isRightLittleInit = false;
    public Vector3 leftHandOffset, rightHandOffset;
    public Vector3 knuckleOffset = new Vector3(0, 0, -0.005f);

    void Update()
    {
        // Im sorry to anyone trying to read this

        // Left Hand
        if(!isLeftPalmInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_Palm") != null)
        {
            leftPalmCollider.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_Palm").transform;
            leftPalmCollider.transform.localPosition = leftHandOffset;
            leftPalmCollider.transform.localEulerAngles = Vector3.zero;
            isLeftPalmInit = true;
        }
        if(!isLeftThumbInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_ThumbMetacarpal/XRHand_ThumbProximal/XRHand_ThumbDistal/XRHand_ThumbTip") != null)
        {
            leftThumb.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_ThumbMetacarpal/XRHand_ThumbProximal/XRHand_ThumbDistal/XRHand_ThumbTip").transform;
            leftThumb.transform.localPosition = Vector3.zero;
            leftThumb.transform.localEulerAngles = Vector3.zero;
            isLeftThumbInit = true;
        }
        if(!isLeftIndexInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate/XRHand_IndexDistal/XRHand_IndexTip") != null)
        {
            leftIndex.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate/XRHand_IndexDistal/XRHand_IndexTip").transform;
            leftIndex.transform.localPosition = Vector3.zero;
            leftIndex.transform.localEulerAngles = Vector3.zero;
            isLeftIndexInit = true;
        }
        if(!isLeftMiddleInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate/XRHand_MiddleDistal/XRHand_MiddleTip") != null)
        {
            leftMiddle.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate/XRHand_MiddleDistal/XRHand_MiddleTip").transform;
            leftMiddle.transform.localPosition = Vector3.zero;
            leftMiddle.transform.localEulerAngles = Vector3.zero;
            isLeftMiddleInit = true;
        }
        if(!isLeftRingInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate/XRHand_RingDistal/XRHand_RingTip") != null)
        {
            leftRing.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate/XRHand_RingDistal/XRHand_RingTip").transform;
            leftRing.transform.localPosition = Vector3.zero;
            leftRing.transform.localEulerAngles = Vector3.zero;
            isLeftRingInit = true;
        }
        if(!isLeftLittleInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate/XRHand_LittleDistal/XRHand_LittleTip") != null)
        {
            leftLittle.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate/XRHand_LittleDistal/XRHand_LittleTip").transform;
            leftLittle.transform.localPosition = Vector3.zero;
            leftLittle.transform.localEulerAngles = Vector3.zero;
            isLeftLittleInit = true;
        }

        // Right Hand
        if(!isRightPalmInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_Palm") != null)
        {
            rightPalmCollider.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_Palm").transform;
            rightPalmCollider.transform.localPosition = rightHandOffset;
            rightPalmCollider.transform.localEulerAngles = Vector3.zero;
            isRightPalmInit = true;
        }
        if(!isRightThumbInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_ThumbMetacarpal/XRHand_ThumbProximal/XRHand_ThumbDistal/XRHand_ThumbTip") != null)
        {
            rightThumb.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_ThumbMetacarpal/XRHand_ThumbProximal/XRHand_ThumbDistal/XRHand_ThumbTip").transform;
            rightThumb.transform.localPosition = Vector3.zero;
            rightThumb.transform.localEulerAngles = Vector3.zero;
            isRightThumbInit = true;
        }
        if(!isRightIndexInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate/XRHand_IndexDistal/XRHand_IndexTip") != null)
        {
            rightIndex.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate/XRHand_IndexDistal/XRHand_IndexTip").transform;
            rightIndex.transform.localPosition = Vector3.zero;
            rightIndex.transform.localEulerAngles = Vector3.zero;
            isRightIndexInit = true;
        }
        if(!isRightMiddleInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate/XRHand_MiddleDistal/XRHand_MiddleTip") != null)
        {
            rightMiddle.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate/XRHand_MiddleDistal/XRHand_MiddleTip").transform;
            rightMiddle.transform.localPosition = Vector3.zero;
            rightMiddle.transform.localEulerAngles = Vector3.zero;
            isRightMiddleInit = true;
        }
        if(!isRightRingInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate/XRHand_RingDistal/XRHand_RingTip") != null)
        {
            rightRing.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate/XRHand_RingDistal/XRHand_RingTip").transform;
            rightRing.transform.localPosition = Vector3.zero;
            leftRing.transform.localEulerAngles = Vector3.zero;
            isRightRingInit = true;
        }
        if(!isRightLittleInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate/XRHand_LittleDistal/XRHand_LittleTip") != null)
        {
            rightLittle.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate/XRHand_LittleDistal/XRHand_LittleTip").transform;
            rightLittle.transform.localPosition = Vector3.zero;
            rightLittle.transform.localEulerAngles = Vector3.zero;
            isRightLittleInit = true;
        }
    }
}
