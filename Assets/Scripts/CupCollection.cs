using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollection : BaseInteractor
{
    [SerializeField] private GameObject cupPrefab;

    public override void Pick()
    {
        Debug.Log("0");
        GameObject temp = Instantiate(cupPrefab);
        CupReceiver cup = temp.GetComponent<CupReceiver>();
        cup.Pick();
        FindObjectOfType<MouseInteractor>().lastPicked = cup;
    }
}