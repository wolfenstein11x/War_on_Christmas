using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 100;


    // use this function as an animation event for Tree
    public void AddMoneyRandInt()
    {
        int amount = Random.Range(7, 12);

        FindObjectOfType<MoneyDisplay>().AddMoney(amount);
    }

    public int GetCost()
    {
        return cost;
    }
}
