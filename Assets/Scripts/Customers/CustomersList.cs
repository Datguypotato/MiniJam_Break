using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersList : MonoBehaviour
{
    [SerializeField] List<Transform> customersPoints = new List<Transform>();
    [SerializeField] Customer cust;
    [SerializeField] List<Customer> customer = new List<Customer>();
    [SerializeField] List<GameObject> objs = new List<GameObject>();

    public int customersCount = 0;
    [SerializeField] int customersMaxCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void instantiateCustomer()
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
        customer[0].served = true;
    }

    void cleanCustomer(GameObject obj)
    {
        Destroy(obj);
    }

    void moveToApoint()
    {
        //transform.position = Vector2.MoveTowards(transform.position, customersPoints[customersCount].position, 1);
        //if (transform.position.y <= customersPoints[customersCount].position.y && customersCount < customersMaxCount)
          //  customersCount++;
    }

    // Update is called once per frame
    void Update()
    {
        instantiateCustomer();
        moveToApoint();
        if (customer[0].served)
        {
            cleanCustomer(objs[0]);
            customer.Remove(customer[0]);
        }
    }
}
