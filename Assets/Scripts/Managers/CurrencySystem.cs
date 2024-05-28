using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] private int cointest;
    private string CURRENCY_SAVE_KEY = "MYGAME_CURRENCY";
    public int totalCoins { get; set; }

    private void Start()
    {
        LoadCoins();
    }
    private void LoadCoins()
    {
        totalCoins = PlayerPrefs.GetInt(CURRENCY_SAVE_KEY,cointest);
    }
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        PlayerPrefs.SetInt(CURRENCY_SAVE_KEY, totalCoins);
        PlayerPrefs.Save();
    }
    public void RemoveCoins(int amount)
    {
        if(totalCoins >= amount) 
        {
            totalCoins -= amount;
            PlayerPrefs.SetInt(CURRENCY_SAVE_KEY, totalCoins);
            PlayerPrefs.Save();
        }
    }
}
