using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyDisplay : MonoBehaviour
{
    static int money = 100;
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        // if we are starting a new game, set lives to full amount
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            money = 100;
        }

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
