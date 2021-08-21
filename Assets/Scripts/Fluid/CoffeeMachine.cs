using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField] private ParticleGenerator generator;

    /// <summary>
    /// Button press on coffee machine
    /// </summary>
    public void TogglePouring()
    {
        generator.isActivated = !generator.isActivated;
    }
}