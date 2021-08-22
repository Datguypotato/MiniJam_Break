using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    private Vector2 spawnPoint = new Vector3(-6f, 0.7f, -1); // left side of the shop

    [SerializeField] private Transform waitingLineParent;
    [SerializeField] private Transform stoolsParent;
    public WaitingLineSpot[] spots;
    public StoolSpot[] stoolspots;

    public int ind = 0;

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
        // testing reason
        if (Input.GetKeyDown(KeyCode.Space))
            InstantiateCustomer();
    }

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
                // fill the spot
                customer.Move(spots[ind].spot);
                spots[ind].isFilled = true;
                spots[ind].currentCustomer = customer;
                
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
