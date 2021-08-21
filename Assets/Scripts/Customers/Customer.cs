using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : BaseInteractor
{
    public int sugarAmount;
    public int milkAmount;
    public bool nextInLine = false;
    [SerializeField] private Vector3 cornerPath;

    public override void Pick()
    {
        base.Pick();
        Debug.Log("Been clicked on!");
        if (nextInLine)
        {
        }
    }

    public void Move(Vector3 newPos)
    {
        Debug.Log("position received " + newPos);
        StartCoroutine(MoveCoroutine(newPos));
    }

    public void Move(Vector3[] newPos)
    {
        Debug.Log("position received " + newPos);
        StartCoroutine(MoveCoroutine(newPos));
    }

    private void settingTheOrderToMake()
    {
        sugarAmount = Random.Range(1, 4);
        milkAmount = Random.Range(1, 10);
    }

    private IEnumerator MoveCoroutine(Vector3 newPos)
    {
        float t = 0;
        while (Vector3.Distance(transform.position, newPos) > 0.1)
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
            while (Vector3.Distance(transform.position, newPos[i]) > 0.1)
            {
                t += Time.deltaTime / 2;
                transform.position = Vector2.Lerp(transform.position, newPos[i], t);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}