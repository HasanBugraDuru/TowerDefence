using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUiManager : MonoBehaviour
{
    [SerializeField] private PlayerDatas playerDatas;
    private TextMeshProUGUI CointText;

    private void Start()
    {
        CointText = GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        CointText.text = playerDatas.CoinAmaount.ToString();
    }
}
