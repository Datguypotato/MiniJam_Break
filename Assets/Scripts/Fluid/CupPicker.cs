using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupPicker : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private BaseCup lastCupPicked;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider)
                Debug.Log(hit.collider.name);

            if (lastCupPicked != null) // drop cup
            {
                lastCupPicked.Reset();
                lastCupPicked = null;
                return;
            }

            if (hit.collider != null && hit.collider.CompareTag("Interactive")) // pick up cup
            {
                BaseCup cup = hit.collider.GetComponent<BaseCup>();
                cup.isGrabbed = true;

                lastCupPicked = cup;
            }
        }
    }
}