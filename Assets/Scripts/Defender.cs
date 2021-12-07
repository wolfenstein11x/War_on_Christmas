using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 100;

    public void AddMoneyRandInt()
    {
        int amount = Random.Range(7, 17);

        FindObjectOfType<MoneyDisplay>().AddMoney(amount);
    }

    public int GetCost()
    {
        return cost;
    }
}
