using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCube : BaseInteractor
{
    [SerializeField] private float speed = 1;

    public override void Pick()
    {
        isGrabbed = true;
    }

    public override void Reset()
    {
        isGrabbed = false;
        gameObject.AddComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2);
    }

    private void Update()
    {
        if (isGrabbed)
        {
            transform.position = cam.ScreenToWorldPoint(Input.mousePosition) - cupOffset;
        }
    }
}