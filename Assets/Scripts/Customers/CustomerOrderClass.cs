using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerOrderClass : MonoBehaviour
{
    CustomerManager customerManager;

    [SerializeField] private TextMeshProUGUI price, ordername, sugar, milk;
    [SerializeField] private string[] orders = { "Coffee", "Coffee with milk", "Sweet Coffe" };

    [SerializeField] private Dictionary<string, int> orderDict = new Dictionary<string, int>();

    Customer[] customers;

    int orderCount = 1;

    private void Start()
    {
        //settingTheOrderToMake();
    }
    public void servingFirstCustomer()
    {
        customerManager.ind--;
        orderCount++;
        foreach (Customer cust in customers)
        {
            cust.Move(customerManager.spots[customerManager.ind].spot);
            customerManager.spots[customerManager.ind].isFilled = false;
        }
    }

    private void settingTheOrderToMake()
    {
        customers = FindObjectsOfType<Customer>();
        foreach(Customer cust in customers)
        {
            if (cust.nextInLine)
            {
                cust.sugarAmount = Random.Range(1, 4);
                cust.milkAmount = Random.Range(1, 10);
                sugar.text  = cust.sugarAmount.ToString();
                milk.text   = cust.milkAmount.ToString();
                price.text = setOrderPrice(cust).ToString();
            }
        }    
    }

    //<summary>
    //This function prints the order name and returns it's price value
    //</summary>
    private int setOrderPrice(Customer cust)
    {
        int ind = 0;
        if (cust.sugarAmount > cust.milkAmount && cust.milkAmount <= 1)
            ind = 0;
        else if (cust.sugarAmount < cust.milkAmount && cust.milkAmount > 1)
            ind = 1;
        else if (cust.sugarAmount > cust.milkAmount && cust.sugarAmount > 5 && cust.milkAmount <= 4)
            ind = 2;
        ordername.text = orders[ind];
        orderDict[orders[ind]] = ind * 2 + 20;
        return orderDict[orders[ind]];
    }

    public void randomizingorder()
    {
        settingTheOrderToMake();
    }

    // Update is called once per frame
    private void Update()
    {
        customerManager = FindObjectOfType<CustomerManager>();
        if (orderCount > 0)
        {
            settingTheOrderToMake();
            orderCount--;
        }
    }
}