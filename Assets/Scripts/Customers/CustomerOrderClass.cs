using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerOrderClass : MonoBehaviour
{
    private CustomerManager customerManager;
    [SerializeField] private OrderManager orderManager;

    [SerializeField] private TextMeshProUGUI price, ordername, sugar, milk;
    [SerializeField] private string[] orders = { "Coffee", "Coffee with milk", "Sweet Coffe" };

    [SerializeField] private Dictionary<string, int> orderDict = new Dictionary<string, int>();
    [SerializeField] private Vector3 cornerPath = new Vector3(-0.7f, -1.5f);

    private Customer[] customers;

    private int orderCount = 1;
    public int stoolInd = 0;

    private void Start()
    {
        customerManager = FindObjectOfType<CustomerManager>();
        customers = FindObjectsOfType<Customer>();
    }

    public void servingFirstCustomer()
    {
        for (int i = 0; i < customerManager.stoolspots.Length; i++)
        {
            if (!customerManager.stoolspots[i].isFilled)
            {
                Customer current = customerManager.GetFirstCustomerInLine();

                //removing old data
                customerManager.stoolspots[i].isFilled = true;
                customerManager.spots[0].isFilled = false;
                customerManager.PushWaitingLine();

                // assigning new customer data
                customerManager.stoolspots[i].currentCustomer = current;
                Vector3[] path = new Vector3[2];
                path[0] = cornerPath;
                path[1] = customerManager.stoolspots[i].spot;
                current.Move(path);

                // update order graphics
                orderManager.order.Invoke();
                return;
            }
        }

        //customerManager.ind--;
        //foreach (Customer cust in customers)
        //{
        //    if (cust.order < customerManager.spots.Length)
        //    {
        //        cust.order--;
        //        if (cust.nextInLine && !cust.served)
        //        {
        //            Vector3[] path = new Vector3[2];
        //            path[0] = cornerPath;
        //            path[1] = customerManager.stoolspots[stoolInd].spot;

        //            cust.Move(path);
        //            cust.served = true;
        //        }
        //        else if (!cust.served)
        //        {
        //            cust.Move(customerManager.spots[cust.order].spot);
        //        }
        //        customerManager.spots[3].isFilled = false;
        //    }
        //}
        //Debug.Log(customerManager.stoolspots.Length);
        //if (stoolInd < customerManager.stoolspots.Length)
        //    stoolInd++;
    }

    //private void settingTheOrderToMake()
    //{
    //    foreach (Customer cust in customers)
    //    {
    //        if (cust.nextInLine)
    //        {
    //            cust.sugarAmount = Random.Range(1, 4);
    //            cust.milkAmount = Random.Range(1, 10);
    //            sugar.text = cust.sugarAmount.ToString();
    //            milk.text = cust.milkAmount.ToString();
    //            price.text = setOrderPrice(cust).ToString();
    //        }
    //    }
    //}

    //<summary>
    //This function prints the order name and returns it's price value
    //</summary>
    //private int setOrderPrice(Customer cust)
    //{
    //    int ind = 0;
    //    if (cust.sugarAmount > cust.milkAmount && cust.milkAmount <= 1)
    //        ind = 0;
    //    else if (cust.sugarAmount < cust.milkAmount && cust.milkAmount > 1)
    //        ind = 1;
    //    else if (cust.sugarAmount > cust.milkAmount && cust.sugarAmount > 5 && cust.milkAmount <= 4)
    //        ind = 2;
    //    ordername.text = orders[ind];
    //    orderDict[orders[ind]] = ind * 2 + 20;
    //    return orderDict[orders[ind]];
    //}

    //public void randomizingorder()
    //{
    //    settingTheOrderToMake();
    //}

    //Update is called once per frame
    //private void Update()
    //{
    //    if (orderCount > 0)
    //    {
    //        settingTheOrderToMake();
    //        orderCount--;
    //    }
    //}
}