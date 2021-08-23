using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderGraphics : MonoBehaviour
{
    private Customer customer;
    [SerializeField] private OrderManager orderManager;
    public int index;
    [SerializeField] private TMP_Text sugarText;
    [SerializeField] private TMP_Text coffeeText;
    [SerializeField] private TMP_Text milkText;

    public void AssignData(OrderData a_Data, Customer a_Customer)
    {
        sugarText.text = a_Data.sugar.ToString();
        coffeeText.text = a_Data.coffee.ToString();
        milkText.text = a_Data.milk.ToString();
        customer = a_Customer;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CupReceiver>() != null)
        {
            CupReceiver cup = collision.GetComponent<CupReceiver>();
            if (!cup.isGrabbed)
            {
                OrderData order = cup.GetOrder();
                customer.CheckOrder(order);
                orderManager.CompleteOrder(this);
                Destroy(cup.gameObject);
            }
        }
    }
}