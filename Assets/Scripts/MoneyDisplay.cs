using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] int money = 100;
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        moneyText.text = money.ToString();
    }

    public bool HaveEnoughMoney(int amount)
    {
        return (money >= amount);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateDisplay();
    }

    public void SpendMoney(int amount)
    {
        if (money < amount) return;

        money -= amount;
        UpdateDisplay();
    }
}
