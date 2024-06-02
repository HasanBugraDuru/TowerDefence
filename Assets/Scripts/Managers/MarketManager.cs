using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    [SerializeField] public PlayerDatas playerDatas;

    private void Awake()
    {
        playerDatas.Market = this.gameObject;
        this.gameObject.SetActive(false);
    }
}
