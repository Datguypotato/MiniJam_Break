using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO
public class Customer : BaseInteractor
{
    public int order;
    public bool nextInLine = false;
    public bool isangry = false, ishappy = false, served = false;
    public OrderData customerOrder;

    [SerializeField] private float waitingTime, maxWaitingTime = 5;

    [SerializeField] private List<SpriteRenderer> shirts = new List<SpriteRenderer>();

    [SerializeField] private int ind;

    [SerializeField]
    private bool reachedTarget = false;

    private void Start()
    {
        ind = Random.Range(0, 8);
        shirts[ind].gameObject.SetActive(true);
        customerOrder = new OrderData(); // get randomize in the constructor
    }

    public override void Pick()
    {
        // happends on click check if they are first in line
        // and add order to some kind of UI
        base.Pick();
        Debug.Log("Been clicked on!");
        if (nextInLine)
        {
        }
    }

    /// <summary>
    /// move to a new position
    /// </summary>
    /// <param name="newPos"></param>
    public void Move(Vector3 newPos)
    {
        // Debug.Log("position received " + newPos);
        StartCoroutine(MoveCoroutine(newPos));
    }

    /// <summary>
    /// move to multiple locations
    /// haven't tested it yet
    /// </summary>
    /// <param name="newPos"></param>
    public void Move(Vector3[] newPos)
    {
        //Debug.Log("position received " + newPos);
        StartCoroutine(MoveCoroutine(newPos));
    }

    public void CheckOrder(OrderData a_Order)
    {
        int difference = 0;
        difference += Mathf.Abs(customerOrder.coffee - a_Order.coffee);
        difference += Mathf.Abs(customerOrder.milk - a_Order.milk);
        difference += Mathf.Abs(customerOrder.sugar - a_Order.sugar);

        ScoreManager.instance.AddScore(difference);
    }

    private void updatingWaitingTime()
    {
        if (nextInLine)
            waitingTime += Time.deltaTime / 2;
        if (waitingTime >= maxWaitingTime)
            isangry = true;
    }

    private void Update()
    {
        //updatingWaitingTime();
        if (isangry)
            Destroy(gameObject);
    }

    private IEnumerator MoveCoroutine(Vector3 newPos)
    {
        float t = 0;
        while (t <= 0.9f)
        {
            // testing reason
            //Debug.Log(t);
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, newPos, t);
            yield return new WaitForEndOfFrame();
        }
        reachedTarget = true;
    }

    private IEnumerator MoveCoroutine(Vector3[] newPos)
    {
        for (int i = 0; i < newPos.Length; i++)
        {
            reachedTarget = false;
            StartCoroutine(MoveCoroutine(newPos[i]));

            while (!reachedTarget)
                yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CustomerManager customerManager = FindObjectOfType<CustomerManager>();
        if (collision.gameObject.transform.position == customerManager.stoolspots[0].spot)
        {
            nextInLine = false;
        }
    }
}

public class OrderData
{
    public int sugar;
    public int coffee;
    public int milk;

    public OrderData()
    {
        sugar = Random.Range(0, 2) * 5;
        coffee = Random.Range(3, 5) * 10;
        milk = Random.Range(0, 30);
    }

    public OrderData(int a_Sugar, int a_Coffee, int a_Milk)
    {
        sugar = a_Sugar;
        coffee = a_Coffee;
        milk = a_Milk;
    }
}