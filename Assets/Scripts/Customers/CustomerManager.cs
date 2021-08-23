using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    private Vector3 spawnPoint = new Vector3(-6f, 0.7f, -8.65f); // left side of the shop

    [SerializeField] private Transform waitingLineParent;
    [SerializeField] private Transform stoolsParent;
    public WaitingLineSpot[] spots;
    public StoolSpot[] stoolspots;

    public int ind = 0;

    public Customer GetFirstCustomerInLine()
    {
        return spots[0].currentCustomer;
    }

    public void PushWaitingLine()
    {
        for (int i = 1; i < spots.Length; i++) // start from index 1
        {
            // move each customer one up
            if (spots[i].isFilled)
            {
                spots[i].isFilled = false;

                spots[i].currentCustomer.Move(spots[i - 1].spot);
                spots[i - 1].currentCustomer = spots[i].currentCustomer;
                spots[i - 1].isFilled = true;
            }
        }
    }

    public void LeaveStool(int a_Index)
    {
        stoolspots[a_Index].currentCustomer.Move(new Vector3(-8.3f, -1.15f));
        stoolspots[a_Index].isFilled = false;
    }

    private void Awake()
    {
        // setting up waiting spots
        spots = new WaitingLineSpot[waitingLineParent.childCount];
        stoolspots = new StoolSpot[stoolsParent.childCount];

        for (int i = 0; i < waitingLineParent.childCount; i++)
        {
            spots[i] = new WaitingLineSpot(waitingLineParent.GetChild(i).transform.position);
        }

        for (int j = 0; j < waitingLineParent.childCount; j++)
        {
            stoolspots[j] = new StoolSpot(stoolsParent.GetChild(j).transform.position);
        }
        InstantiateCustomer();
    }

    private void Update()
    {
        //UpdateCustomerLine();
        InstantiateCustomer();
    }

    //private void UpdateCustomerLine()
    //{
    //    Customer[] customers = FindObjectsOfType<Customer>();
    //    foreach (Customer cust in customers)
    //    {
    //        if (cust.order == 0)
    //            cust.nextInLine = true;
    //        else
    //            cust.nextInLine = false;
    //    }
    //}

    // function for updating position
    private void InstantiateCustomer()
    {
        for (ind = 0; ind < spots.Length; ind++)
        {
            if (!spots[ind].isFilled) // not filled
            {
                GameObject temp = Instantiate(customerPrefab, spawnPoint, Quaternion.identity);
                Customer customer = temp.GetComponent<Customer>();
                customer.order = ind;
                if (customer.order == 0)
                    customer.nextInLine = true;
                // fill the spot
                customer.Move(spots[ind].spot);
                spots[ind].isFilled = true;
                spots[ind].currentCustomer = customer;

                //return;
            }
        }
        //Debug.Log("Waiting line full");
    }
}

[System.Serializable]
public class WaitingLineSpot
{
    public Vector3 spot;
    public bool isFilled;
    public Customer currentCustomer;

    public WaitingLineSpot(Vector3 a_Spot)
    {
        spot = a_Spot;
        isFilled = false;
    }
}

[System.Serializable]
public class StoolSpot
{
    public Vector3 spot;
    public bool isFilled;
    public Customer currentCustomer;

    public StoolSpot(Vector3 a_Spot)
    {
        spot = a_Spot;
        isFilled = false;
    }
}