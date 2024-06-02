using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDatas",menuName = "Player Datas")]
public class PlayerDatas : ScriptableObject
{
    [SerializeField] public bool MusicOn;
    [SerializeField] public bool SoundOn;
    [SerializeField] public int CoinAmaount;
    [SerializeField] public GameObject UpgradeLocation;
    [SerializeField] public GameObject Market;
    [SerializeField] public GameObject Esc;
}
