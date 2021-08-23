using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For updating the graphics for the orders coffee making
/// </summary>
public class OrderManager : MonoBehaviour
{
    private CustomerManager customerManager;

    public delegate void OnNewCustomerUpdate();

    public OnNewCustomerUpdate order;
    [SerializeField] private GameObject[] ordersObjects;

    private void Start()
    {
        customerManager = FindObjectOfType<CustomerManager>();
        order += UpdateOrders;
    }

    // Called from CustomerOrderClass
    private void UpdateOrders()
    {
        for (int i = 0; i < customerManager.stoolspots.Length; i++)
        {
            StoolSpot spot = customerManager.stoolspots[i];
            if (spot.isFilled)
            {
                ordersObjects[i].SetActive(true);
                ordersObjects[i].GetComponent<OrderGraphics>().AssignData(spot.currentCustomer.customerOrder, spot.currentCustomer);
            }
        }
    }

    public void CompleteOrder(OrderGraphics orderGraphics)
    {
        orderGraphics.gameObject.SetActive(false);
        customerManager.LeaveStool(orderGraphics.index);
    }
}