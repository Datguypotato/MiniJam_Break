using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCup : MonoBehaviour
{
    public bool isGrabbed = false;

    [SerializeField] protected Camera cam;
    [SerializeField] protected Vector3 cupOffset;

    protected void Update()
    {
        if (!isGrabbed)
            return;

        transform.position = cam.ScreenToWorldPoint(Input.mousePosition) - cupOffset;
    }

    /// <summary>
    /// For resseting in it original state when rightclick to drop something
    /// </summary>
    virtual public void Reset()
    {
        isGrabbed = false;
    }
}