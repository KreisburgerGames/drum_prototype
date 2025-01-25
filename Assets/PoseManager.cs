using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoseManager : MonoBehaviour
{
    public static PoseManager instance;
    public PoseState leftPoseState = PoseState.None;
    public PoseState rightPostState = PoseState.None;

    public enum PoseState
    {
        Fist,
        Palm,
        None
    }
    public void InitHands()
    {
        ResetLeft();
        ResetRight();
    }

    void Awake()
    {
        instance = this;
    }

    public void LeftRock()
    {
        print("Left rock");
        leftPoseState = PoseState.Fist;
        foreach(GameObject knuckle in GameObject.FindGameObjectsWithTag("Knuckle"))
        {
            if(knuckle.gameObject.name.Contains("Left"))
                knuckle.GetComponent<ColliderManager>().EnableCollider();
        }
        foreach(GameObject fingertip in GameObject.FindGameObjectsWithTag("Fingertip"))
        {
            if(fingertip.gameObject.name.Contains("Left"))
                fingertip.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject palm in GameObject.FindGameObjectsWithTag("Palm"))
        {
            if(palm.gameObject.name.Contains("Left"))
                palm.GetComponent<ColliderManager>().DisableCollider();
        }
    }

    public void RightRock()
    {
        print("Right rock");
        rightPostState = PoseState.Fist;
        foreach(GameObject knuckle in GameObject.FindGameObjectsWithTag("Knuckle"))
        {
            if(knuckle.gameObject.name.Contains("Right"))
                knuckle.GetComponent<ColliderManager>().EnableCollider();
        }
        foreach(GameObject fingertip in GameObject.FindGameObjectsWithTag("Fingertip"))
        {
            if(fingertip.gameObject.name.Contains("Right"))
                fingertip.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject palm in GameObject.FindGameObjectsWithTag("Palm"))
        {
            if(palm.gameObject.name.Contains("Right"))
                palm.GetComponent<ColliderManager>().DisableCollider();
        }
    }

    public void OpenLeft()
    {
        print("Left open");
        leftPoseState = PoseState.Palm;
        foreach(GameObject knuckle in GameObject.FindGameObjectsWithTag("Knuckle"))
        {
            if(knuckle.gameObject.name.Contains("Left"))
                knuckle.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject fingertip in GameObject.FindGameObjectsWithTag("Fingertip"))
        {
            if(fingertip.gameObject.name.Contains("Left"))
                fingertip.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject palm in GameObject.FindGameObjectsWithTag("Palm"))
        {
            if(palm.gameObject.name.Contains("Left"))
                palm.GetComponent<ColliderManager>().EnableCollider();
        }
    }

    public void OpenRight()
    {
        print("Right open");
        rightPostState = PoseState.Palm;
        foreach(GameObject knuckle in GameObject.FindGameObjectsWithTag("Knuckle"))
        {
            if(knuckle.gameObject.name.Contains("Right"))
                knuckle.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject fingertip in GameObject.FindGameObjectsWithTag("Fingertip"))
        {
            if(fingertip.gameObject.name.Contains("Right"))
                fingertip.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject palm in GameObject.FindGameObjectsWithTag("Palm"))
        {
            if(palm.gameObject.name.Contains("Right"))
                palm.GetComponent<ColliderManager>().EnableCollider();
        }
    }

    public void ResetLeft()
    {
        print("Left reset");
        leftPoseState = PoseState.None;
        foreach(GameObject knuckle in GameObject.FindGameObjectsWithTag("Knuckle"))
        {
            if(knuckle.gameObject.name.Contains("Left"))
                knuckle.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject fingertip in GameObject.FindGameObjectsWithTag("Fingertip"))
        {
            if(fingertip.gameObject.name.Contains("Left"))
                fingertip.GetComponent<ColliderManager>().EnableCollider();
        }
        foreach(GameObject palm in GameObject.FindGameObjectsWithTag("Palm"))
        {
            if(palm.gameObject.name.Contains("Left"))
                palm.GetComponent<ColliderManager>().DisableCollider();
        }
    }

    public void ResetRight()
    {
        print("Right reset");
        rightPostState = PoseState.None;
        foreach(GameObject knuckle in GameObject.FindGameObjectsWithTag("Knuckle"))
        {
            if(knuckle.gameObject.name.Contains("Right"))
                knuckle.GetComponent<ColliderManager>().DisableCollider();
        }
        foreach(GameObject fingertip in GameObject.FindGameObjectsWithTag("Fingertip"))
        {
            if(fingertip.gameObject.name.Contains("Right"))
                fingertip.GetComponent<ColliderManager>().EnableCollider();
        }
        foreach(GameObject palm in GameObject.FindGameObjectsWithTag("Palm"))
        {
            if(palm.gameObject.name.Contains("Right"))
                palm.GetComponent<ColliderManager>().DisableCollider();
        }
    }
}
