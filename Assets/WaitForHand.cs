using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForHand : MonoBehaviour
{
    public GameObject leftPalmCollider, leftThumb, leftIndex /*INDEX??? VALVE REFERENCE*/, leftMiddle, leftRing, leftLittle, leftIndexKnuckle, leftMiddleKnuckle, leftRingKnuckle, leftLittleKnuckle;
    public GameObject rightPalmCollider, rightThumb, rightIndex /*uhhh can't make another reference*/, rightMiddle, rightRing, rightLittle, rightIndexKnuckle, rightMiddleKnuckle, rightRingKnuckle, rightLittleKnuckle;
    private bool isLeftPalmInit, isLeftThumbInit, isLeftIndexInit, isLeftMiddleInit, isLeftRingInit, isLeftLittleInit, isLeftIndexKnuckleInit, isLeftMiddleKnuckleInit, isLeftRingKnuckleInit, isLeftLittleKnuckleInit = false;
    private bool isRightPalmInit, isRightThumbInit, isRightIndexInit, isRightMiddleInit, isRightRingInit, isRightLittleInit, isRightIndexKnuckleInit, isRightMiddleKnuckleInit, isRightRingKnuckleInit, isRightLittleKnuckleInit = false;
    public Vector3 palmOffset = new Vector3(0, -0.025f, 0);
    public Vector3 knuckleOffset = new Vector3(0, 0, -0.005f);

    void Update()
    {
        // Im sorry to anyone trying to read this

        // Left Hand
        if(!isLeftPalmInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_Palm") != null)
        {
            leftPalmCollider.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_Palm").transform;
            leftPalmCollider.transform.localPosition = palmOffset;
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
        if(!isLeftIndexKnuckleInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate") != null)
        {
            leftIndexKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate").transform;
            leftIndexKnuckle.transform.localPosition = knuckleOffset;
            leftIndexKnuckle.transform.localEulerAngles = Vector3.zero;
            isLeftIndexKnuckleInit = true;
        }
        if(!isLeftMiddleKnuckleInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate") != null)
        {
            leftMiddleKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate").transform;
            leftMiddleKnuckle.transform.localPosition = knuckleOffset;
            leftMiddleKnuckle.transform.localEulerAngles = Vector3.zero;
            isLeftMiddleKnuckleInit = true;
        }
        if(!isLeftRingKnuckleInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate") != null)
        {
            leftRingKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate").transform;
            leftRingKnuckle.transform.localPosition = knuckleOffset;
            leftRingKnuckle.transform.localEulerAngles = Vector3.zero;
            isLeftRingKnuckleInit = true;
        }
        if(!isLeftLittleKnuckleInit && GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate") != null)
        {
            leftLittleKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/LeftHandAnchor/LeftTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate").transform;
            leftLittleKnuckle.transform.localPosition = knuckleOffset;
            leftLittleKnuckle.transform.localEulerAngles = Vector3.zero;
            isLeftLittleKnuckleInit = true;
        }

        // Right Hand
        if(!isRightPalmInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_Palm") != null)
        {
            rightPalmCollider.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_Palm").transform;
            rightPalmCollider.transform.localPosition = palmOffset;
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
        if(!isRightIndexKnuckleInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate") != null)
        {
            rightIndexKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_IndexMetacarpal/XRHand_IndexProximal/XRHand_IndexIntermediate").transform;
            rightIndexKnuckle.transform.localPosition = knuckleOffset;
            rightIndexKnuckle.transform.localEulerAngles = Vector3.zero;
            isRightIndexKnuckleInit = true;
        }
        if(!isRightMiddleKnuckleInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate") != null)
        {
            rightMiddleKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_MiddleMetacarpal/XRHand_MiddleProximal/XRHand_MiddleIntermediate").transform;
            rightMiddleKnuckle.transform.localPosition = knuckleOffset;
            rightMiddleKnuckle.transform.localEulerAngles = Vector3.zero;
            isRightMiddleKnuckleInit = true;
        }
        if(!isRightRingKnuckleInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate") != null)
        {
            rightRingKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_RingMetacarpal/XRHand_RingProximal/XRHand_RingIntermediate").transform;
            rightRingKnuckle.transform.localPosition = knuckleOffset;
            rightRingKnuckle.transform.localEulerAngles = Vector3.zero;
            isRightRingKnuckleInit = true;
        }
        if(!isRightLittleKnuckleInit && GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate") != null)
        {
            rightLittleKnuckle.transform.parent = GameObject.Find("Player/TrackingSpace/RightHandAnchor/RightTracking/Bones/XRHand_Wrist/XRHand_LittleMetacarpal/XRHand_LittleProximal/XRHand_LittleIntermediate").transform;
            rightLittleKnuckle.transform.localPosition = knuckleOffset;
            rightLittleKnuckle.transform.localEulerAngles = Vector3.zero;
            isRightLittleKnuckleInit = true;
        }

        // Disable script one colliders are ready
        StartCheckColliders();
    }

    private void StartCheckColliders()
    {
        StartCoroutine(CheckColliders());
    }

    private IEnumerator CheckColliders()
    {
        if(GetComponentsInChildren<Transform>().Length == 1)
        {
            FindFirstObjectByType<PoseManager>().InitHands();
            Destroy(gameObject);
        }
        
        yield return new WaitForSeconds(1f);
        StartCheckColliders();
    }
}
