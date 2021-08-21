using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupReceiver : BaseCup
{
    [SerializeField] private Transform fillTransform;
    [SerializeField] private SpriteRenderer fillColor;

    [Header("Colors")]
    [SerializeField] private Color coffeeColor;

    //[SerializeField] private Color coffeeColorDark; my be used in the future
    [SerializeField] private Color coffeeColorLight;

    [SerializeField] private Color milkColor;

    private DynamicParticle.STATES currentState;
    private bool isEmpty = true;
    private float mixureLevel = 0; // for lerping

    private float maxScale = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DynamicParticle"))
        {
            if (fillTransform.transform.localScale.y < maxScale)
            {
                Debug.Log("Getting filled");
                fillTransform.transform.localScale += new Vector3(0, 1, 0);

                if (isEmpty) // for the first base color fill
                {
                    SetCup(collision.GetComponent<DynamicParticle>());
                }
                else // "mix" the colours together
                {
                    LerpColor(collision.GetComponent<DynamicParticle>());
                }

                Destroy(collision.gameObject);
            }
        }
    }

    private void SetCup(DynamicParticle particle)
    {
        switch (particle.GetState())
        {
            case DynamicParticle.STATES.COFFEE:
                fillColor.color = coffeeColor;
                currentState = DynamicParticle.STATES.COFFEE;
                break;

            case DynamicParticle.STATES.MILK:
                fillColor.color = milkColor;
                currentState = DynamicParticle.STATES.MILK;
                break;

            default:
                break;
        }
        isEmpty = false;
    }

    private void LerpColor(DynamicParticle particle)
    {
        if (currentState != particle.GetState())
        {
            switch (particle.GetState())
            {
                case DynamicParticle.STATES.COFFEE:
                    mixureLevel += 0.01f;
                    fillColor.color = Color.Lerp(fillColor.color, coffeeColor, mixureLevel);
                    break;

                case DynamicParticle.STATES.MILK:
                    mixureLevel += 0.01f;
                    fillColor.color = Color.Lerp(fillColor.color, coffeeColorLight, mixureLevel);
                    break;

                default:
                    break;
            }
        }
    }
}