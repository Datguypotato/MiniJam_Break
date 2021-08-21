using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the player cup for pouring stuff in other cups
/// </summary>
public class CupBehaviour : BaseInteractor
{
    private ParticleGenerator particleGenerator;
    [SerializeField] private float rotateSpeed = 1;
    private bool isPooring;

    private void Start()
    {
        particleGenerator = GetComponentInChildren<ParticleGenerator>();
    }

    public override void Reset()
    {
        base.Reset();
        if (isPooring) // if it is in a active state reset it back to normal
            StartCoroutine(Pour());
    }

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(Pour());
    }

    public override void Pick()
    {
        base.Pick();
        isGrabbed = true;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!isGrabbed)
            return;

        transform.position = cam.ScreenToWorldPoint(Input.mousePosition) - cupOffset;
    }

    private IEnumerator Pour()
    {
        if (isPooring)
        {
            // rotate left
            while (transform.rotation.eulerAngles.z > 1)
            {
                transform.Rotate(new Vector3(0, 0, -1));
                yield return new WaitForEndOfFrame();
            }
            isPooring = false;
        }
        else
        {
            // rotate right
            while (transform.rotation.eulerAngles.z < 100)
            {
                transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed);
                yield return new WaitForEndOfFrame();
            }
            isPooring = true;
        }

        particleGenerator.isActivated = isPooring; // update pouring state
    }
}