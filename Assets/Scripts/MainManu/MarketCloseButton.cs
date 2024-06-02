using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketCloseButton : MonoBehaviour
{
    [SerializeField] private GameObject Market;
    [SerializeField] private GameObject prefab;
    [SerializeField] private PlayerDatas playerDatas;
    [SerializeField] private int TowerCost;

    public void MarketClose()
    {
        Market.SetActive(false);
    }
    public void CloseMarket()
    {
        playerDatas.UpgradeLocation = this.gameObject;
        playerDatas.Market.SetActive(false);
    }

    public void OpenMarket()
    {
        playerDatas.UpgradeLocation = this.gameObject;
        playerDatas.Market.SetActive(true);
    }

    public void Buy()
    {
        if (playerDatas.CoinAmaount >= TowerCost)
        {
            Instantiate(prefab,playerDatas.UpgradeLocation.transform.position, playerDatas.UpgradeLocation.transform.rotation);
            playerDatas.CoinAmaount -= TowerCost;
            Market.SetActive(false);
            playerDatas.UpgradeLocation.SetActive(false);
        }
       

    }
}
