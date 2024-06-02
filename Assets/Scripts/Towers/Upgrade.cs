using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private PlayerDatas playerDatas;
    [SerializeField] private GameObject UpgradeButtons;
    [SerializeField] private GameObject Tower;
    [SerializeField] private GameObject Place;
    [SerializeField] private GameObject PlacePrefab;
    [SerializeField] private int SellMoney;

    public void OpenButtons()
    {
        UpgradeButtons.SetActive(true);
    }
    public void UpgradeBtn()
    {

    }
    public void Destroy()
    {
        playerDatas.CoinAmaount += SellMoney;
        Place.transform.parent = null; 
        Place.SetActive(true);
        Destroy(this.transform.root.gameObject);
        UpgradeButtons.SetActive(false);
    }
}
