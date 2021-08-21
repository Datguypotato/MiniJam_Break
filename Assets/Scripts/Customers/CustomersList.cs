using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersList : MonoBehaviour
{
    [SerializeField] private List<Transform> customersPoints = new List<Transform>();
    [SerializeField] private Customer cust;
    [SerializeField] private List<Customer> customer = new List<Customer>();
    [SerializeField] private List<GameObject> objs = new List<GameObject>();

    public int customersCount = 0;
    [SerializeField] private int customersMaxCount = 5;

    private void instantiateCustomer()
    {
        if (customersCount < customersMaxCount)
        {
            GameObject obj = Instantiate(cust.gameObject, transform.position, Quaternion.identity);
            customer.Add(cust);
            objs.Add(obj);
            customersCount++;
        }
    }

    public void serveTest()
    {
        //customer[0].served = true;
    }

    private void cleanCustomer(GameObject obj)
    {
        Destroy(obj);
    }

    private void moveToApoint()
    {
        //transform.position = Vector2.MoveTowards(transform.position, customersPoints[customersCount].position, 1);
        //if (transform.position.y <= customersPoints[customersCount].position.y && customersCount < customersMaxCount)
        //  customersCount++;
    }

    // Update is called once per frame
    private void Update()
    {
        instantiateCustomer();
        moveToApoint();
        //if (customer[0].served)
        {
            cleanCustomer(objs[0]);
            customer.RemoveAt(0);
        }
    }
}