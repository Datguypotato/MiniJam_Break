using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseInteractor
{
    private GameObject coffeeParent;
    private GameObject cafeParent;

    protected override void Start()
    {
        base.Start();
        cafeParent.SetActive(true);
        coffeeParent.SetActive(false);
    }

    public override void Pick()
    {
        // toggle between the two parent
    }
}