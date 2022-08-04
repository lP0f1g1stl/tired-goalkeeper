using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int _coins;
    public int Coins 
    { 
        get => _coins;
        set => _coins = value;
    }
}
