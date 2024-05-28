using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDatas",menuName = "Player Datas")]
public class PlayerDatas : ScriptableObject
{
    [SerializeField] public bool MusicOn;
    [SerializeField] public bool SoundOn;
    [SerializeField] public int Cointest;
}
