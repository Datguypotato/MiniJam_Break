using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField] private ParticleGenerator generator;

    public void TogglePouring()
    {
        generator.isActivated = !generator.isActivated;
    }
}