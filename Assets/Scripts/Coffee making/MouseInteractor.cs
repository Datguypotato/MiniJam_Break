using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractor : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] public BaseInteractor lastPicked;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit.point);
            // debug reasons
            //if (hit.collider)
            //    Debug.Log(hit.collider.name);

            if (lastPicked != null) // Reset object
            {
                lastPicked.Reset();
                lastPicked = null;
                return;
            }

            if (hit.collider != null && hit.collider.CompareTag("Interactive")) // pick up interactable
            {
                BaseInteractor cup = hit.collider.GetComponent<BaseInteractor>();
                if (cup == null)
                    return;

                //Debug.Log(cup);
                lastPicked = cup;
                cup.Pick();
            }
        }

        if (Input.GetMouseButtonDown(1) && lastPicked != null) // use said object
        {
            lastPicked.Interact();
        }
    }
}