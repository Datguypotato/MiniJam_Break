using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    CustomerOrderClass customerOrder;

    public bool served = false;

    // Start is called before the first frame update
    void Start()
    {
        served = false;
        customerOrder = FindObjectOfType<CustomerOrderClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
