using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderClass : MonoBehaviour
{
    [SerializeField] private Text price, ordername;
    [SerializeField] private string[] orders = { "Coffee", "Coffe with milk", "Sweet Coffe" };

    [SerializeField] private Dictionary<string, int> orderDict = new Dictionary<string, int>();

    public float sugarAmount, milkAmount;

    private void settingTheOrderToMake()
    {
        sugarAmount = Random.Range(1, 4);
        milkAmount = Random.Range(1, 10);
    }

    private int setOrderPrice()
    {
        int ind = 0;
        if (sugarAmount > milkAmount && milkAmount <= 1)
            ind = 0;
        else if (sugarAmount < milkAmount && milkAmount > 1)
            ind = 1;
        else if (sugarAmount > milkAmount && sugarAmount > 5 && milkAmount <= 4)
            ind = 2;
        orderDict[orders[ind]] = ind * 2 + 20;
        testing(ref ind);
        return orderDict[orders[ind]];
    }

    // TESTING THE CUSTOMER OREDER CLASS
    private void testing(ref int n)
    {
        ordername.text = orders[n];
    }

    // Start is called before the first frame update
    private void Start()
    {
        settingTheOrderToMake();
    }

    public void randomizingorder()
    {
        settingTheOrderToMake();
    }

    // Update is called once per frame
    private void Update()
    {
        //int price = setOrderPrice();
        price.text = setOrderPrice().ToString();
    }
}