using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// For resseting in it original state when rightclick to drop something
    /// </summary>
    virtual public void Reset()
    {
        isGrabbed = false;
    }
}