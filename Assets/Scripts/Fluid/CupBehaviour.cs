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

    private void Start()
    {
        particleGenerator = GetComponentInChildren<ParticleGenerator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!isGrabbed)
            return;

        base.Update();
        // tilting the cup
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Pour());
            Debug.Log("click");
        }

        //Debug.Log(transform.rotation.eulerAngles.z + " > " + titltRightMax);
        // pour only if it is rotate so far
        particleGenerator.isActivated = isPooring;
    }

    private IEnumerator Pour()
    {
        if (isPooring)
        {
            while (transform.rotation.eulerAngles.z > 1)
            {
                transform.Rotate(new Vector3(0, 0, -1));
                yield return new WaitForEndOfFrame();
            }
            isPooring = false;
        }
        else
        {
            while (transform.rotation.eulerAngles.z < 100)
            {
                transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed);
                yield return new WaitForEndOfFrame();
            }
            isPooring = true;
        }
    }
}