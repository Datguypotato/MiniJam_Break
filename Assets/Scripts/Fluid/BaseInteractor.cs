using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base of everything interactable
/// they must have the tag Interactable
/// </summary>
public class BaseInteractor : MonoBehaviour
{
    public bool isGrabbed = false;

    [SerializeField] protected Camera cam;
    [SerializeField] protected Vector3 cupOffset;

    // on left click
    public virtual void Pick()
    {

    }

    // on right click
    public virtual void Interact()
    {

    }

    /// <summary>
    /// For reseting in it original state
    /// </summary>
    virtual public void Reset()
    {
        isGrabbed = false;
    }
}