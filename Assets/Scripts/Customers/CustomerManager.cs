using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    private Vector2 spawnPoint = new Vector3(-6f, 0.7f, -1); // left side of the shop

    [SerializeField] private Transform waitingLineParent;
    [SerializeField] private WaitingLineSpot[] spots;

    private void Start()
    {
        // setting up waiting spots
        spots = new WaitingLineSpot[waitingLineParent.childCount];
        for (int i = 0; i < waitingLineParent.childCount; i++)
        {
            spots[i] = new WaitingLineSpot(waitingLineParent.GetChild(i).transform.position);
        }

        InstantiateCustomer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            InstantiateCustomer();
    }

    private void InstantiateCustomer()
    {
        for (int i = 0; i < spots.Length; i++)
        {
            if (!spots[i].isFilled) // not filled
            {
                GameObject temp = Instantiate(customerPrefab, spawnPoint, Quaternion.identity);
                Customer customer = temp.GetComponent<Customer>();

                // fill the spot
                customer.Move(spots[i].spot);
                spots[i].isFilled = true;
                spots[i].currentCustomer = customer;
                return;
            }
        }
        Debug.Log("Waiting line full");
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