using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CupReceiver : BaseInteractor
{
    [SerializeField] private Transform fillTransform;
    [SerializeField] private SpriteRenderer fillColor;

    [Header("Colors")]
    [SerializeField] private Color coffeeColor;

    [SerializeField] private Color coffeeColorLight;
    [SerializeField] private Color milkColor;

    [Header("Content")]
    [SerializeField] private int coffeeAmount;

    [SerializeField] private int milkAmount;
    [SerializeField] private int sugarCubes;

    [SerializeField] private TMP_Text cupInfoText;

    private DynamicParticle.STATES currentState;
    private bool isEmpty = true;
    private float mixureLevel = 0; // for lerping

    private float maxScale = 100;

    public override void Reset()
    {
        base.Reset();
        isGrabbed = false;
    }

    public override void Pick()
    {
        base.Pick();
        isGrabbed = true;
    }

    public override void Interact()
    {
        base.Interact();
        // nothing yet
    }

    private void Update()
    {
        if (!isGrabbed)
            return;

        transform.position = cam.ScreenToWorldPoint(Input.mousePosition) - cupOffset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DynamicParticle"))
        {
            if (fillTransform.transform.localScale.y <= maxScale)
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

                AddContent(collision.GetComponent<DynamicParticle>());
                Destroy(collision.gameObject);
            }
        }
    }

    private void AddContent(DynamicParticle particle)
    {
        switch (particle.GetState())
        {
            case DynamicParticle.STATES.COFFEE:
                coffeeAmount++;
                break;

            case DynamicParticle.STATES.MILK:
                milkAmount++;
                break;

            default:
                break;
        }
        cupInfoText.text = $"Coffee: {coffeeAmount} \nMilk: {milkAmount} \nSugar: {sugarCubes}";
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