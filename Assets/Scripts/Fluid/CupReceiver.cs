using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupReceiver : MonoBehaviour
{
    [SerializeField] private Transform fill;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DynamicParticle"))
        {
            if (fill.transform.localScale.y < 100)
                fill.transform.localScale += new Vector3(0, 10, 0);
        }
    }
}