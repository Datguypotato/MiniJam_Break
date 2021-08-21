using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBehaviour : MonoBehaviour
{
    private ParticleGenerator particleGenerator;
    [SerializeField] private Vector3 cupOffset;
    [SerializeField] private Camera cam;

    private void Start()
    {
        particleGenerator = GetComponentInChildren<ParticleGenerator>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition) - cupOffset;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, 0, 1f));
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 0, -1f));

        particleGenerator.isActivated = (transform.rotation.eulerAngles.z > 100);
    }
}