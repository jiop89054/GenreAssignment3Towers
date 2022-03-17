using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static int Points;
    public int startMoney = 400;

    public float moneyRate;
    public float moneyCooldown;
    public int moneyGained;

    public GameObject moneyText;
    public GameObject lifeText;

    public int maxLife;
    public int remainingLife;

    void Start()
    {
        Points = startMoney;
        remainingLife = maxLife;
    }

    private void Update()
    {
        if (moneyCooldown <= 0f)
        {
            Points += moneyGained;
            moneyCooldown = moneyRate;
        }

        moneyCooldown -= Time.deltaTime;

        moneyText.GetComponent<TextMeshProUGUI>().text = "Money: " + Mathf.Floor(Points).ToString();

        lifeText.GetComponent<TextMeshProUGUI>().text = "Life: " + Mathf.Floor(remainingLife).ToString();
    }
    public void takeDamage()
    {
        remainingLife = remainingLife - 1;
        if(remainingLife == 0)
        {
            FindObjectOfType<MenuScript>().LoadLevel("EndScreen 1");
        }
    }

}
