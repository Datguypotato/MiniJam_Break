using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the player cup for pouring stuff in other cups
/// </summary>
public class CupBehaviour : BaseCup
{
    private ParticleGenerator particleGenerator;
    [SerializeField] private float rotateSpeed = 1;
    private bool isPooring;

    public override void Reset()
    {
        base.Reset();
        if (isPooring) // if it is in a active state reset it back to normal
            StartCoroutine(Pour());
    }

    private void Start()
    {
        particleGenerator = GetComponentInChildren<ParticleGenerator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();
        if (!isGrabbed)
            return;

        // tilting the cup
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Pour());
            Debug.Log("click");
        }
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