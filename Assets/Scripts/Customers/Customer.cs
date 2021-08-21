using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO
public class Customer : BaseInteractor
{
    public int sugarAmount;
    public int milkAmount;
    public bool nextInLine = false;
    public bool isangry = false , ishappy = false;
    [SerializeField] private Vector3 cornerPath;

    [SerializeField] float waitingTime, maxWaitingTime = 5;

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
        Debug.Log("position received " + newPos);
        StartCoroutine(MoveCoroutine(newPos));
    }

    /// <summary>
    /// move to multiple locations
    /// haven't tested it yet
    /// </summary>
    /// <param name="newPos"></param>
    public void Move(Vector3[] newPos)
    {
        Debug.Log("position received " + newPos);
        StartCoroutine(MoveCoroutine(newPos));
    }

    /// <summary>
    /// Called when clicked on customer
    /// </summary>
    private void settingTheOrderToMake()
    {
        sugarAmount = Random.Range(1, 4);
        milkAmount  = Random.Range(1, 10);
    }

    void updatingWaitingTime()
    {
        waitingTime += Time.deltaTime / 3;
        if (waitingTime >= maxWaitingTime)
            isangry = true;
    }


    private IEnumerator MoveCoroutine(Vector3 newPos)
    {
        float t = 0;
        while (Vector3.Distance(transform.position, newPos) > 0.1f)
        {
            t += Time.deltaTime / 2;
            transform.position = Vector2.Lerp(transform.position, newPos, t);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MoveCoroutine(Vector3[] newPos)
    {
        for (int i = 0; i < newPos.Length; i++)
        {
            float t = 0;
            while (Vector3.Distance(transform.position, newPos[i]) > 0.1f)
            {
                t += Time.deltaTime / 2;
                transform.position = Vector2.Lerp(transform.position, newPos[i], t);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}