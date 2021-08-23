using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseInteractor
{
    [SerializeField]
    public GameObject coffeeParent;

    protected override void Start()
    {
        base.Start();
        coffeeParent.SetActive(false);
    }

    public override void Pick()
    {
        // toggle between the two parent
        coffeeParent.SetActive(!coffeeParent.activeInHierarchy);
    }
}